using System;
using System.Runtime.Serialization;

namespace PerreraTeam.Exceptions
{
    [Serializable]
    public class RazasException : Exception
    {
        public RazasException()
        {
        }

        public RazasException(string message) : base(message)
        {
        }

        public RazasException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RazasException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}