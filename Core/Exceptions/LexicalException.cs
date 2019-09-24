using System;

namespace Core.Exceptions
{
    public class LexicalException : Exception
    {
        private int line;

        public LexicalException(string message) : base(message)
        {
        }

        public LexicalException(string message, int line) : base(message)
        {
            this.line = line;
        }

        public int GetLine()
        {
            return line;
        }
    }
}
