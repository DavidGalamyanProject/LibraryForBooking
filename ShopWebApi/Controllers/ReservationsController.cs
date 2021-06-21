using Microsoft.AspNetCore.Mvc;
using ShopWebApi.Domain;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Model.Dto;
using System;

namespace ShopWebApi.Controllers
{
	/// <summary> Контроллер для резервации. </summary>
	[Route("[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationManager _reservationManager;

        public ReservationsController(IReservationManager reservationManager)
        {
            _reservationManager = reservationManager;            
        }

        /// <summary> Добавляет заявку на резерв. </summary>
        /// <param name="request"> Назавание товара, количество резерва.</param>
        /// <returns>Id заявки.</returns>
        [HttpPost]
        public IActionResult ReservProduct([FromBody] ReservRequest request)
        {
			var createReservRequest = new ReservRequestToQueue()
			{
				IdOrder = Guid.NewGuid(),
				ProductName = request.ProductName,
				Quantity = request.Quantity,
				ReservationTime = DateTime.UtcNow
			};
			Accounting.RequestReservQueue.Enqueue(createReservRequest);
			var response = new ReserveResponse() { Id = createReservRequest.IdOrder };

			return Ok(response);
        }

        /// <summary> Проверяет зарезервировался-ли товар. </summary>
        [HttpGet("id/{id}")]
        public IActionResult CheckReserv([FromRoute] Guid id)
        {
            var result = _reservationManager.GetReservById(id);
            if (result != null)
            {
                return Ok("Товар зарезервирован.");
            }
            return BadRequest("Товар не зарезервирован.");
        }
    }
}
