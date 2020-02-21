using System;
using System.Runtime.Serialization;

namespace PerreraTeam.Exceptions
{
    [Serializable]
    internal class ClientesException : Exception
    {
        public ClientesException()
        {
        }

        public ClientesException(string message) : base(message)
        {
        }

        public ClientesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}