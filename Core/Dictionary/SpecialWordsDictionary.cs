using Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;


namespace Core.Dictionary
{
    class SpecialWordsDictionary
    {
        public Dictionary<string, SpecialWordsEnum> Operators = new Dictionary<string, SpecialWordsEnum>
        {
             { ":", SpecialWordsEnum.Colon },
             { "=", SpecialWordsEnum.Comparation },
             { ":=", SpecialWordsEnum.Equal },
             { "[", SpecialWordsEnum.LeftBracket },
             { "(", SpecialWordsEnum.LeftParentheses },
             { "]", SpecialWordsEnum.RightBracket },
             { ")", SpecialWordsEnum.RightParentheses },
             { ",", SpecialWordsEnum.Coma },
             { ";", SpecialWordsEnum.SemiColon },
             { ".", SpecialWordsEnum.Point },
             { ":", SpecialWordsEnum.DoublePoints },
             { "$", SpecialWordsEnum.DollarSign },
        };
    }
}
