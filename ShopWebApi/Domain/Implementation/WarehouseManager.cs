using ShopWebApi.Data.Interfaces;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Infrastructure.Exceptions;
using ShopWebApi.Model.Dto;
using ShopWebApi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopWebApi.Domain.Implementation
{
    public class WarehouseManager : IWarehouseManager
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IProductManager _productManager;

        public WarehouseManager(IWarehouseRepository warehouseRepository, IProductManager productManager)
        {
            _warehouseRepository = warehouseRepository;
            _productManager = productManager;
        }

        public async Task<Guid> CreateStockPosition(StockPositionAddRequest request)
        {
            var product = _productManager.GetProductByName(request.ProductName);
            if(product == null)
            {
                throw new LackOfProductException();
            }
            var stockPosition = new StockPosition
            {
                VendorCode = Guid.NewGuid(),
                Product = product,
                Quantity = request.Quantity
            };
            await _warehouseRepository.AddStockPosition(stockPosition);
            return stockPosition.VendorCode;
        }

        public List<StockPosition> GetAllStockPositions()
        {
            return _warehouseRepository.GetAllStockPositions().Result;
        }

        public StockPosition GetStockPosition(Product product)
        {
            var result = _warehouseRepository.GetStockPositionByProduct(product);
            return result;
        }

        public void UpdateStockPositionWarehouse(StockPosition productInWarehouse)
        {
            _warehouseRepository.UpdateProductWarehouse(productInWarehouse);
        }

        public StockPosition UpdateStockPositionWarehouseByVendorCode(StockPositionUpdateRequest request)
        {
            var result = _warehouseRepository.GetStockPositionByGuid(request.VendorCode);
            result.Quantity = request.Quantity;
            _warehouseRepository.UpdateProductWarehouse(result);
            return result;
        }
    }
}
