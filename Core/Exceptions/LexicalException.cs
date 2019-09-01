using System;

namespace Core.Exceptions
{
    public class LexicalException : Exception
    {
        public LexicalException(string message) : base(message)
        {
        }
    }
}
