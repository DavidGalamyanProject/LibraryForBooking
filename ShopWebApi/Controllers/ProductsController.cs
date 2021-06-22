using Microsoft.AspNetCore.Mvc;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Model.Dto;
using System.Threading.Tasks;

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
        public async Task<IActionResult> RegisregisterProduct([FromBody] ProductRequest request)
        {
            if (string.IsNullOrEmpty(request.ProductName))
            {
                return BadRequest("Поле, имя продукта, не заполнено.");
            }
            var result = await _productManager.CreateProduct(request);
            return Ok(result);
        }
    }
}
