using System;

namespace LibraryBookingGoods.Dto
{
    /// <summary> Ответ, на добавление товара в резерв</summary>
    internal class ReserveResponse
    {
        /// <summary> Id резерва </summary>
        public Guid Id { get; set; }
    }
}
