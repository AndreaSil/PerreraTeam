using System;
using System.Runtime.Serialization;

namespace PerreraTeam.Exceptions
{
    [Serializable]
    public class EmpleadosException : Exception
    {
        public EmpleadosException()
        {
        }

        public EmpleadosException(string message) : base(message)
        {
        }

        public EmpleadosException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmpleadosException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}