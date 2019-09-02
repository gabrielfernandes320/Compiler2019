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
             { "and", OperatorEnum.And },
             { "not", OperatorEnum.Not },
             { "or", OperatorEnum.Or },
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
