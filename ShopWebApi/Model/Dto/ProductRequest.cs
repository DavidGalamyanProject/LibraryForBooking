using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApi.Model.Dto
{
    /// <summary> Запрос, для регистрации товара. </summary>
    public class ProductRequest
    {
        /// <summary> Название продукта. </summary>
        public string ProductName { get; set; }

        /// <summary> Информация о продукте. </summary>
        public string ProductInformation { get; set; }
    }
}
