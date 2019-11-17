using System;

namespace Core.Exceptions
{
    public class SemanticException : Exception
    {
        private int line;

        public SemanticException(string message) : base(message)
        {
        }

        public SemanticException(string message, int line) : base(message)
        {
            this.line = line;
        }

        public int GetLine()
        {
            return line;
        }
    }
}
