namespace ShopWebApi.Model.Dto
{
    /// <summary> Модель запроса, для резерва товара </summary>
    public class ReservRequest
    {
        /// <summary> Название продукта </summary>
        public string ProductName { get; set; }

        /// <summary> Колличество продукта </summary>
        public int Quantity { get; set; }
    }
}
