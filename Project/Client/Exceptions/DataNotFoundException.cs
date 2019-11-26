using System;
using System.Runtime.Serialization;

namespace Client.Exceptions
{
    /// <summary>
    /// Exception for data not found
    /// </summary>
    public class DataNotFoundException : Exception
    {

        public DataNotFoundException()
        {
        }

        public DataNotFoundException(string message) : base(message)
        {
        }

    }
}