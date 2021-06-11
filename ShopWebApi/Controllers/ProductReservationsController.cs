using Microsoft.AspNetCore.Mvc;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Model.Dto;
using System;
using System.Threading.Tasks;

namespace ShopWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductReservationsController : ControllerBase
    {
        private readonly IProductReservationManager _productManager;

        public ProductReservationsController(IProductReservationManager productManager)
        {
            _productManager = productManager;
        }
        [HttpPost]
        public async Task<IActionResult> ReservProduct([FromBody] ProductReservRequest request)
        {
            var timeNow = DateTime.UtcNow;
            var resultReserv = await _productManager.MakeAReservationProduct(request, timeNow);
            if(resultReserv == null)
            {
                return BadRequest();
            }
            return Ok(resultReserv);
        }
    }
}
