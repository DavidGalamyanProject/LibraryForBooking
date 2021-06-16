using Microsoft.AspNetCore.Mvc;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Model.Dto;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace ShopWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductReservationsController : ControllerBase
    {
        private readonly IReservationManager _productManager;
        private readonly IWarehouseManager _warehouseManager;

        public ProductReservationsController(IReservationManager productManager, IWarehouseManager warehouseManager)
        {
            _productManager = productManager;
            _warehouseManager = warehouseManager;
        }
        [HttpPost]
        public IActionResult ReservProduct([FromBody] ProductReservRequest request)
        {
            var resultReserv = _productManager.AddRequestToQueue(request);

            if(resultReserv == null)
            {
                return BadRequest();
            }

            return Ok(resultReserv);
        }
        [HttpPut]
        public async Task<IActionResult> Upload()
        {
            _productManager.UploadReservList();
            await _warehouseManager.UploadProductList();
            return Ok();
        }
    }
}
