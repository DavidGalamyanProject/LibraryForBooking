# ShopWebApi  

## Docs API  

*[На главную](./../README.md)  

### Список Api:  

ProductsController:  
[HttpPost] Регистрация товара в базе данных.

ReservationsController:  
[HttpPost] Добавляет заявку на резерв товара в очередь.  
[HttpGet("id/{id}")] Проверяет зарезервировался-ли товар. Если все прошло успешно, Вы получите статус код 200.  

WarehousesController:  
[HttpPost] Создает позицию товара на складе. Возвращает VendorCode(Guid) позиции.  
[HttpPut] Изменяет колличество товара на складе по VendorCode(Guid). Возвращает новый экземпляр StockPosition.  
[HttpGet] Возвращает список позиций на складе.