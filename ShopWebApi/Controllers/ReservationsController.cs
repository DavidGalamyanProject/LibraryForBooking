using Microsoft.AspNetCore.Mvc;
using ShopWebApi.Domain;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Model.Dto;
using System;

namespace ShopWebApi.Controllers
{
    /// <summary> Контроллер для резервации </summary>
    [Route("[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationManager _productManager;

        public ReservationsController(IReservationManager productManager)
        {
            _productManager = productManager;            
        }

        /// <summary> Добавляет заявку на резерв </summary>
        /// <param name="request">Тело запроса</param>
        /// <returns>Id заявки</returns>
        [HttpPost]
        public IActionResult ReservProduct([FromBody] ReservRequest request)
        {
            var resultReserv = _productManager.AddRequestToQueue(request);

            return Ok(resultReserv);
        }

        /// <summary> Проверяет зарезервировался-ли товар. </summary>
        /// <param name="id">Guid заявки на резерв</param>
        /// <returns> Возвращает сообщение типа string</returns>
        [HttpGet("id/{id}")]
        public IActionResult CheckReserv([FromRoute] Guid id)
        {
            if (Accounting.ListOfReservedProducts.TryGetValue(id, out string message))
            {
                return Ok(message);
            }
            return BadRequest("Неверный Guid");
        }

        [HttpPut]
        public IActionResult UpdateBase()
        {
            _productManager.ReservProducts();
            return Ok();
        }
    }
}
