using System;

namespace checkout.Exceptions
{
    class BusinessException : ApplicationException
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
}
