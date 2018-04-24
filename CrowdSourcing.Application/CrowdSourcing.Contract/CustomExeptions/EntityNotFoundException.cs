using System;

namespace CrowdSourcing.Contract.CustomExeptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message) { }
        public EntityNotFoundException(string message, Exception ex) : base(message, ex) { }
    }
}
