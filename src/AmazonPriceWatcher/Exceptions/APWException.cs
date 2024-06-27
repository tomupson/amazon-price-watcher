using System;

namespace apw.Exceptions
{
    public class APWException : Exception
    {
        public APWException(string message) : base(message)
        {
        }
    }
}