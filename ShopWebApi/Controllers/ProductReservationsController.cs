using Microsoft.AspNetCore.Mvc;
using ShopWebApi.Domain;
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
        private readonly IReservationManager _productManager;

        public ProductReservationsController(IReservationManager productManager)
        {
            _productManager = productManager;            
        }
        [HttpPost]
        public IActionResult ReservProduct([FromBody] ProductReservRequest request)
        {
            var resultReserv = _productManager.AddRequestToQueue(request);

            return Ok(resultReserv);
        }
        [HttpGet("id/{id}")]
        public IActionResult CheckReserv([FromRoute] Guid id)
        {
            if (SingletonAccounting.ListOfReservedProducts.ContainsKey(id))
            {
                return Ok(id);
            }
            return BadRequest();

        }
        [HttpGet]
        public IActionResult Upload()
        {
            _productManager.UploadReservList();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateBase()
        {
            _productManager.ReservProducts();
            return Ok();
        }
    }
}
