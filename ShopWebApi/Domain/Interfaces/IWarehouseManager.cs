using ShopWebApi.Model.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopWebApi.Domain.Interfaces
{
    public interface IWarehouseManager
    {
        /// <summary>Загружает Dictionary товаров со склада, помещает их в статик поле класса SingletonAccounting </summary>
        Warehouse GetProduct(Product product);
        void UpdateProductWarehouse(Warehouse productInWarehouse);
    }
}
