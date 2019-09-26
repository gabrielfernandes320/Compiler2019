using System;

namespace Core.Exceptions
{
    public class SyntacticalException : Exception
    {
        private int line;

        public SyntacticalException(string message) : base(message)
        {
        }

        public SyntacticalException(string message, int line) : base(message)
        {
            this.line = line;
        }

        public int GetLine()
        {
            return line;
        }
    }
}
