using System;
using System.Runtime.Serialization;

namespace PerreraTeam.Exceptions
{
    [Serializable]
    internal class AdopcionesException : Exception
    {
        public AdopcionesException()
        {
        }

        public AdopcionesException(string message) : base(message)
        {
        }

        public AdopcionesException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AdopcionesException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}