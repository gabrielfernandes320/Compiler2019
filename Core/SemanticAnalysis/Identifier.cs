using System;
using System.Collections.Generic;
using System.Text;

namespace Core.SemanticAnalysis
{
    public class Identifier
    {
        public Identifier()
        {
        }

        public string Name { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }

    }
}
