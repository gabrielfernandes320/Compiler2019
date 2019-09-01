using System;
using System.Collections.Generic;
using System.Text;
using Core.Enum;

namespace Core.Dictionary
{
    class OperatorsDictionary
    {
        public IDictionary<string, OperatorEnum> operators = new Dictionary<string, OperatorEnum>
        {
             { "And", OperatorEnum.And },
             { "Not", OperatorEnum.Not },
             { "Or", OperatorEnum.Or },
             { "+", OperatorEnum.Plus  },
             { "-", OperatorEnum.Minus },
             { "*", OperatorEnum.Mult },
             { "/", OperatorEnum.Div },
             { ">", OperatorEnum.GreaterThan },
             { "<", OperatorEnum.LessThan },
             { ">=", OperatorEnum.GreaterOrEqual },
             { "<=", OperatorEnum.LessOrEqual },
             { "<>", OperatorEnum.NotEqual },
        };
    }
}
