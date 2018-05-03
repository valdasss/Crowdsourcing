using System;

namespace CrowdSourcing.Contract.CustomExeptions
{
    class ValidationException : Exception
    {
        public ValidationException(string message) : base(message) { }
        public ValidationException(string message, Exception ex) : base(message, ex) { }
    }
}
