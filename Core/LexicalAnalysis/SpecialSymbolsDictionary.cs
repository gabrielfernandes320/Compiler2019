using Core.Enum;
using System.Collections.Generic;

namespace Core.LexicalAnalysis
{
    public static class SpecialSymbolsDictionary
    {
        private static readonly IDictionary<string, SpecialSymbolEnum> specialSymbols = new Dictionary<string, SpecialSymbolEnum>
        {
             { ":", SpecialSymbolEnum.Colon },
             { "=", SpecialSymbolEnum.Comparation },
             { ":=", SpecialSymbolEnum.Equal },
             { "[", SpecialSymbolEnum.LeftBracket },
             { "(", SpecialSymbolEnum.LeftParentheses },
             { "]", SpecialSymbolEnum.RightBracket },
             { ")", SpecialSymbolEnum.RightParentheses },
             { ",", SpecialSymbolEnum.Coma },
             { ";", SpecialSymbolEnum.SemiColon },
             { ".", SpecialSymbolEnum.Point },
             { "..", SpecialSymbolEnum.DoublePoints },
             { "$", SpecialSymbolEnum.DollarSign },
        };

        public static IDictionary<string, SpecialSymbolEnum> Get()
        {
            return specialSymbols;
        }
    }
}
