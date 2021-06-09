using ShopWebApi.Data.Interfaces;
using ShopWebApi.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApi.Data.Implementation
{
    public class StorageWarehouseRepository : IStorageWarehouseRepository
    {
        public Task AddProductToBase(ProductAddRequest request)
        {
            throw new NotImplementedException();
        }

        public Task GetAllProduct()
        {
            throw new NotImplementedException();
        }

        public Task GetProduct(ProductCheckRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
