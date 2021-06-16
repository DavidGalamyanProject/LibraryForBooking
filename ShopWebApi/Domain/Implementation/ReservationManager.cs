using ShopWebApi.Data.Interfaces;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Model.Dto;
using ShopWebApi.Model.Entity;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;

namespace ShopWebApi.Domain.Implementation
{
    public class ReservationManager : IReservationManager
    {
        private readonly IReservationRepository _reservRepository;
        private readonly IWarehouseManager _warehouseManager;
        public ReservationManager(IReservationRepository reservRepository, IWarehouseManager warehouseManager)
        {
            _reservRepository = reservRepository;
            _warehouseManager = warehouseManager;
        }

        public ReserveProductResponse AddRequestToQueue(ProductReservRequest request)
        {
            var check = SingletonAccounting.ProductsWarehouse.ContainsKey(request.ProductName);
            if (!check)
            { 
                return default;
            }
            if (SingletonAccounting.RequestReservQueue == null)
            {
                SingletonAccounting.RequestReservQueue = new ConcurrentQueue<ReservedProduct>();
            }
            
            SingletonAccounting.RequestReservQueue.Enqueue(new ReservedProduct
            {
                IdOrder = Guid.NewGuid(),
                ProductName = request.ProductName,
                Quantity = request.Quantity,
                ReservationTime = DateTime.UtcNow
            });
            if (SingletonAccounting.RequestReservQueue.Count > 500)
            {
               ReservProducts();
            }
            return new ReserveProductResponse() {Id = Guid.NewGuid()};
        }

        private void ReservProducts()
        {
            var list = SingletonAccounting.RequestReservQueue.ToImmutableArray();
            var tempList = new List<ReservedProduct>();
            SingletonAccounting.RequestReservQueue.Clear();
            foreach(var reserv in list)
            {
                if(SingletonAccounting.ProductsWarehouse[reserv.ProductName] - reserv.Quantity >= 0)
                {
                    SingletonAccounting.ProductsWarehouse[reserv.ProductName] -= reserv.Quantity;
                    tempList.Add(reserv);
                }
            }
            var productsWarehouse = SingletonAccounting.ProductsWarehouse.ToImmutableDictionary();
            _reservRepository.AddReserveProducts(tempList);
            _warehouseManager.UpdateProductWarehouse(productsWarehouse);
        }

        public void UploadReservList()
        {
            SingletonAccounting.ReservList = _reservRepository.GetReservProducts();
        }
    }
}
