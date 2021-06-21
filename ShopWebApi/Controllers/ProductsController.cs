using Microsoft.AspNetCore.Mvc;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Model.Dto;

namespace ShopWebApi.Controllers
{
    /// <summary> Контроллер для работы с товаром. </summary>
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductManager _productManager;

        public ProductsController(IProductManager productManager)
        {
            _productManager = productManager;
        }

        /// <summary> Регистрирует товар в базе данных. </summary>
        [HttpPost] 
        public IActionResult RegisregisterProduct([FromBody] ProductRequest request)
        {
            if (string.IsNullOrEmpty(request.ProductName))
            {
                return BadRequest("Поле, имя продукта, не заполнено.");
            }
            var result =  _productManager.CreateProduct(request).Result;
            return Ok(result);
        }
    }
}
