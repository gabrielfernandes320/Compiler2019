using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class CharWrapper
    {
        public char Char { get; set; }

        public int Line { get; set; }

        public int Position { get; set; }

        public override string ToString()
        {
            return Char.ToString();
        }
    }
}
