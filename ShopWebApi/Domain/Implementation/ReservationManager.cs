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

        public Reserv GetReservById(Guid id)
        {
            var result = _reservRepository.GetReservById(id);
            return result;
        }

        public void ReservProducts()
        {
            // Достаем из нашей очереди все запросы (конвертируя в лист для чтения), после чего очищаем нашу очередь.
            var listRequest = Accounting.GetImmutableList();

            // Сюда помещаются резервы кторые возможно было сделать в момент запроса
            var tempReservList = new List<Reserv>();

            foreach (var reserv in listRequest)
            {                
                // Поиск такого товара в базе
                var productInfo = _productManager.GetProductByName(reserv.ProductName);
                // Поиск позиции на складе
                var productInWarehouse = _warehouseManager.GetStockPosition(productInfo);
				if (productInfo == null || productInWarehouse == null)
				{
					continue;
				}                
                if (productInWarehouse.Quantity - reserv.Quantity >= 0)
                {
                    productInWarehouse.Quantity -= reserv.Quantity;
                    // Если товара достаточно, отнимаем необходимое колличество и сохраняем в базе
                    _warehouseManager.UpdateStockPositionWarehouse(productInWarehouse);
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

            }         
            // После того как весь список запросов на резерв был проверен, можем создать резервы в базе
            _reservRepository.AddReserveProducts(tempReservList);
        }

        public void UploadReservList()
        {
            var result = _reservRepository.GetReservProducts();
            foreach (var item in result)
            {
                Accounting.ListOfReservedProducts.GetOrAdd(item.IdOrder,"Успешный резерв");
            }            
        }
    }
}
