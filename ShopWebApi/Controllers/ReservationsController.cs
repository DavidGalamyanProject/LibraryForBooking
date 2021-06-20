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
        private readonly IReservationManager _reservationManager;

        public ReservationsController(IReservationManager reservationManager)
        {
            _reservationManager = reservationManager;            
        }

        /// <summary> Добавляет заявку на резерв </summary>
        /// <param name="request"> Нзавание товара, количество резерва</param>
        /// <returns>Id заявки</returns>
        [HttpPost]
        public IActionResult ReservProduct([FromBody] ReservRequest request)
        {
            var resultReserv = _reservationManager.AddRequestToQueue(request);

            return Ok(resultReserv);
        }

        /// <summary> Проверяет зарезервировался-ли товар. </summary>
        [HttpGet("id/{id}")]
        public IActionResult CheckReserv([FromRoute] Guid id)
        {
            var result = _reservationManager.GetReservById(id);
            if (result != null)
            {
                return Ok("Товар зарезервирован");
            }
            return BadRequest("Товар не зарезервирован");
        }
    }
}
