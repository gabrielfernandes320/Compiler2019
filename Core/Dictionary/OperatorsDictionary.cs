using System;
using System.Collections.Generic;
using System.Text;
using Core.Enum;

namespace Core.Dictionary
{
    class OperatorsDictionary
    {
        public Dictionary<string, OperatorsEnum> Operators = new Dictionary<string, OperatorsEnum>
        {
             { "And", OperatorsEnum.And },
             { "Not", OperatorsEnum.Not },
             { "Or", OperatorsEnum.Or },
             { "+", OperatorsEnum.Plus  },
             { "-", OperatorsEnum.Minus },
             { "*", OperatorsEnum.Mult },
             { "/", OperatorsEnum.Div },
             { ">", OperatorsEnum.GreaterThan },
             { "<", OperatorsEnum.LessThan },
             { ">=", OperatorsEnum.GreaterOrEqual },
             { "<=", OperatorsEnum.LessOrEqual },
             { "<>", OperatorsEnum.NotEqual },
        };
    }
}
