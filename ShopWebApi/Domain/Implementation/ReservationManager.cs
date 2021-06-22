using ShopWebApi.Data.Interfaces;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ShopWebApi.Domain.Implementation
{
	public class ReservationManager : IReservationManager
    {
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

        public async Task<Reserv> GetReservById(Guid id)
        {
            var result = await _reservRepository.GetReservById(id);
            return result;
        }

        public void ReservProducts()
        {
			// Пока в очереди есть эллементы
			for (int i = 0; i < 2000; i++)
			{			
				if (Accounting.RequestReservQueue.TryDequeue(out var reserv))
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
						// Добавляем зарезервированный товар в базу
						_reservRepository.AddReserve(reservProduct);
					}
				}
				else
				{
					break;
				}
			}
		}
        
    }
}
