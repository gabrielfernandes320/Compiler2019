using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Enum
{

    public enum SpecialWordsEnum
    {
        //[StringValue("[")]
        LeftBracket = 34,

        //[StringValue("]")]
        RightBracket = 35,

        //[StringValue("(")]
        LeftParentheses = 36,

        //[StringValue(")")]
        RightParentheses = 37,

        //[StringValue(":=")]
        Equal = 38,

        //[StringValue(":")]
        Colon = 39,

        //[StringValue("=")]
        Comparation = 40,
    }
}
