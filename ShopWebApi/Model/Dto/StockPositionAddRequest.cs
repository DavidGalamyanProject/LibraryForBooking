namespace ShopWebApi.Model.Dto
{
    /// <summary> Запрос на добавление позиции на складе </summary>
    public class StockPositionAddRequest
    {
        /// <summary> Название продукта </summary>
        public string ProductName { get; set; }

        /// <summary> Колличество продукта </summary>
        public int Quantity { get; set; }
    }
}
