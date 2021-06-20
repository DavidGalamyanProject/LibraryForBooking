using System;

namespace ShopWebApi.Model.Dto
{
    /// <summary> Ответ, на добавление товара в резерв</summary>
    public class ReserveResponse
    {
        /// <summary> Id резерва </summary>
        public Guid Id { get; set; }
    }
}
