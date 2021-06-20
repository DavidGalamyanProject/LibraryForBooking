using System;

namespace ShopWebApi.Infrastructure.Exceptions
{
    public class LackOfProductException : Exception
    {
        public override string Message => _message;

        private readonly string _message = "Пожалуйста, сначала зарегестрируйте товар";
        public LackOfProductException()
        {
        }
    }
}
