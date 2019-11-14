using System;
using System.Runtime.Serialization;

namespace Client.Exceptions
{
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