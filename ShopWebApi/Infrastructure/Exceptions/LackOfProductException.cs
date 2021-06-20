using System;

namespace ShopWebApi.Infrastructure.Exceptions
{
    public class LackOfProductException : Exception
    {
        public override string Message => _message;

        private readonly string _message = "Такой товар не зарегистрирован.";
        public LackOfProductException()
        {
        }
    }
}
