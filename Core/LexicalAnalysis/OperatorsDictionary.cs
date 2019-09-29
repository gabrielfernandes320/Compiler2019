using Core.Enums;
using System.Collections.Generic;

namespace Core.LexicalAnalysis
{
    public static class OperatorsDictionary
    {
        private static readonly IDictionary<string, OperatorEnum> operators = new Dictionary<string, OperatorEnum>
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

        public static IDictionary<string, OperatorEnum> Get()
        {
            return operators;
        }
    }
}
