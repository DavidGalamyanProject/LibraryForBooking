using Microsoft.AspNetCore.Mvc;
using ShopWebApi.Domain.Interfaces;
using ShopWebApi.Infrastructure.Exceptions;
using ShopWebApi.Model.Dto;
using System.Threading.Tasks;

namespace ShopWebApi.Controllers
{
    /// <summary> Контроллер для работы со складом. </summary>
    [Route("[controller]")]
    [ApiController]
    public class WarehousesController : ControllerBase
    {
        private readonly IWarehouseManager _warehouseManager;
        public WarehousesController(IWarehouseManager warehouseManager)
        {
            _warehouseManager = warehouseManager;
        }

        /// <summary> Создает позицию товара на складе. </summary>
        /// <returns> Возвращает VendorCode(Guid) позиции.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateStockPosition([FromBody] StockPositionAddRequest requset)
        {
            try
            {
                var result = await _warehouseManager.CreateStockPosition(requset);
                return Ok(result);
            }
            catch (LackOfProductException ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        /// <summary> Изменяет колличество товара на складе по VendorCode(Guid). </summary>
        /// <returns> Возвращает новый экземпляр StockPosition. </returns>
        [HttpPut]
        public IActionResult UpdateStockPosition([FromBody] StockPositionUpdateRequest request)
        {
            var result = _warehouseManager.UpdateStockPositionWarehouseByVendorCode(request);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Неверный VendorCode");
        }

        /// <summary> Возвращает список позиций на складе. </summary>
        [HttpGet]
        public async Task<IActionResult> AllStockPosition()
        {
            var result = await _warehouseManager.GetAllStockPositions();
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("На складе нет позиций");
        }
    }
}
