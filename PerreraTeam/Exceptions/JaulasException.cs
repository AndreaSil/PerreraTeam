using System;
using System.Runtime.Serialization;

namespace PerreraTeam.Exceptions
{
    [Serializable]
    internal class JaulasException : Exception
    {
        public JaulasException()
        {
        }

        public JaulasException(string message) : base(message)
        {
        }

        public JaulasException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected JaulasException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}