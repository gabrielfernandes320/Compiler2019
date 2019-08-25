using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Token
    {
        public int Code;

        public string Value;

        public Token(int code, string value)
        {
            Code = code;
            Value = value;
        }
    }
}
