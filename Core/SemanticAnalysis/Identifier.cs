using System;
using System.Collections.Generic;
using System.Text;

namespace Core.SemanticAnalysis
{
    public class Identifier
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }

        public static explicit operator Predicate<object>(Identifier v)
        {
            throw new NotImplementedException();
        }
    }
}
