using System;

namespace ShopWebApi.Infrastructure.Exceptions
{
	/// <summary> Exception, выкидывается, если позиции товара, не существует на складе. </summary>
    public class LackOfProductException : Exception
    {
        public override string Message => _message;

        private readonly string _message = "Такой товар не зарегистрирован.";
        public LackOfProductException()
        {
        }
    }
}
