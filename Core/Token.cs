using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Token
    {
        public int Code { get; set; }

        public char Value { get; set; }

        public Token(int code, char value)
        {
            Code = code;
            Value = value;
        }

        public Token()
        {
        }
    }
}
