using ShopWebApi.Data.Interfaces;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Model;
using ShopWebApi.Model.Dto;
using ShopWebApi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

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

        public ReserveProductResponse AddRequestToQueue(ProductReservRequest request)
        {            
            lock (_lock)
            {
                var createReservRequest = new ReservRequestToQueue()
                {
                    IdOrder = Guid.NewGuid(),
                    ProductName = request.ProductName,
                    Quantity = request.Quantity,
                    ReservationTime = DateTime.UtcNow
                };
                SingletonAccounting.RequestReservQueue.Enqueue(createReservRequest);
                return new ReserveProductResponse() { Id = createReservRequest.IdOrder };
            }
        }

        public void ReservProducts()
        {
            // Достаем из нашей очереди все запросы (конвертируя в лист для чтения), после чего очищаем нашу очередь.
            // Данная очередь потока безопасна, поэтому мы можем гарантировать, что во время очищения,
            // никто ничего не записывал и не читал из нее.
            var listRequest = SingletonAccounting.RequestReservQueue.ToImmutableList(); /// !TODO lock singlton
            SingletonAccounting.RequestReservQueue.Clear();
            // Сюда помещаются резервы кторые возможно было сделать с момент запроса
            var tempReservList = new List<Reserv>();
            foreach (var reserv in listRequest)
            {                
                var productInfo = _productManager.GetProductByName(reserv.ProductName);
                var productInWarehouse = _warehouseManager.GetProduct(productInfo);
                if (productInWarehouse == null || productInfo == null)
                {
                    continue;
                }
                if (productInWarehouse.Quantity - reserv.Quantity >= 0)
                {
                    productInWarehouse.Quantity -= reserv.Quantity;
                    _warehouseManager.UpdateProductWarehouse(productInWarehouse);
                    var reservProduct = new Reserv
                    {
                        IdOrder = reserv.IdOrder,
                        Product = productInfo,
                        ReservationTime = reserv.ReservationTime,
                        Quantity = reserv.Quantity
                    };
                    tempReservList.Add(reservProduct);
                }
            }            
            _reservRepository.AddReserveProducts(tempReservList);
            UploadReservList();
        }

        public void UploadReservList()
        {
            SingletonAccounting.ListOfReservedProducts = _reservRepository.GetReservProducts();
        }
    }
}
