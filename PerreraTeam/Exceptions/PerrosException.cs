using System;
using System.Runtime.Serialization;

namespace PerreraTeam.Exceptions
{
    [Serializable]
    public class PerrosException : Exception
    {
        public PerrosException()
        {
        }

        public PerrosException(string message) : base(message)
        {
        }

        public PerrosException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PerrosException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}