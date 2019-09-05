using System;
using System.Collections.Generic;

namespace Core
{
    public class Token
    {
        public System.Enum Type { get; set; }

        public int Code {
            get
            {
                return (int)Convert.ChangeType(Type, Type.GetTypeCode());
            }
        }

        public string Value { get; set; }

        public CharWrapper StartChar { get; set; }
    }
}
