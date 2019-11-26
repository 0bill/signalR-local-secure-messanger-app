using System;
using System.Runtime.Serialization;

namespace Client.Exceptions
{
    /// <summary>
    /// Exception for user token not valid
    /// </summary>
    public class TokenNotValidException : Exception
    {
        public TokenNotValidException()
        {
        }

        protected TokenNotValidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public TokenNotValidException(string message) : base(message)
        {
        }

        public TokenNotValidException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}