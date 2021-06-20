using ShopWebApi.Data.Interfaces;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Model.Dto;
using ShopWebApi.Model.Entity;
using System;
using System.Collections.Generic;

namespace ShopWebApi.Domain.Implementation
{
    public class ReservationManager : IReservationManager
    {
        private readonly object _lock = new object();
        private readonly IReservationRepository _reservRepository;
        private readonly IProductManager _productManager;
        private readonly IWarehouseManager _warehouseManager;
        public ReservationManager(IReservationRepository reservRepository, IWarehouseManager warehouseManager,
            IProductManager productManager)
        {
            _reservRepository = reservRepository;
            _warehouseManager = warehouseManager;
            _productManager = productManager;
        }

        public ReserveResponse AddRequestToQueue(ReservRequest request)
        {            
            // Лочим, что бы потоки ничего не украли друг у друга
            lock (_lock)
            {
                var createReservRequest = new ReservRequestToQueue()
                {
                    IdOrder = Guid.NewGuid(),
                    ProductName = request.ProductName,
                    Quantity = request.Quantity,
                    ReservationTime = DateTime.UtcNow
                };
                Accounting.RequestReservQueue.Enqueue(createReservRequest);
                return new ReserveResponse() { Id = createReservRequest.IdOrder };
            }
        }

        public void ReservProducts()
        {
            // Достаем из нашей очереди все запросы (конвертируя в лист для чтения), после чего очищаем нашу очередь.
            var listRequest = Accounting.GetImmutableList();

            string messageProductNotExist = "Такого товара нет на скаладе (неверно указано название товара)";
            string messageProductOutStock = "Товар закончился";

            // Сюда помещаются резервы кторые возможно было сделать в момент запроса
            var tempReservList = new List<Reserv>();

            foreach (var reserv in listRequest)
            {                
                // Поиск такого товара в базе
                var productInfo = _productManager.GetProductByName(reserv.ProductName);
                // Поиск позиции на складе
                var productInWarehouse = _warehouseManager.GetProduct(productInfo);

                if ( productInfo == null)
                {
                    // Если такого товара нет, запишем сообщение, ввели неверное имя товара
                    Accounting.ListOfReservedProducts.TryAdd(reserv.IdOrder, messageProductNotExist);
                    continue;
                }
                
                if (productInWarehouse.Quantity - reserv.Quantity >= 0)
                {
                    productInWarehouse.Quantity -= reserv.Quantity;
                    // Если товара достаточно, отнимаем необходимое колличество и сохраняем в базе
                    _warehouseManager.UpdateProductWarehouse(productInWarehouse);
                    var reservProduct = new Reserv
                    {
                        IdOrder = reserv.IdOrder,
                        Product = productInfo,
                        ReservationTime = reserv.ReservationTime,
                        Quantity = reserv.Quantity
                    };
                    // Добавляем товар в список для резерва
                    tempReservList.Add(reservProduct);
                }

                else
                {
                    // Если товар закончился, запишем сообщение, товар закончился
                    Accounting.ListOfReservedProducts.TryAdd(reserv.IdOrder, messageProductOutStock);
                    continue;
                }

            }         
            // После того как весь список запросов на резерв был проверен, можем создать резервы в базе
            _reservRepository.AddReserveProducts(tempReservList);            
            UploadReservList();
        }

        public void UploadReservList()
        {
            var result = _reservRepository.GetReservProducts();
            string message = "Успешный резевр!";
            // Добавляем все резервы с сообщением о успешном резерве!
            foreach (var item in result)
            {
                Accounting.ListOfReservedProducts.AddOrUpdate(item.IdOrder, message, (key, oldValue) => message);
            }
        }
    }
}
