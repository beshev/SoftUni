using System;

namespace _07.CustomException
{
    class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException(string message)
        {
            this.Message = message;
        }
        public override string Message { get; }
    }
}
