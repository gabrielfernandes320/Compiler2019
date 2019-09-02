using Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Dictionary
{
    class SpecialSymbolsDictionary
    {
        public IDictionary<string, SpecialSymbolEnum> symbols = new Dictionary<string, SpecialSymbolEnum>
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
    }
}
