
using System;

namespace TwoCardPoker.Exceptions
{
    public class HandOverflowException : Exception
    {
        public HandOverflowException(string message)
        : base(message)
        {
        }
    }
}
