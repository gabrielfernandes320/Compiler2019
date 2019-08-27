using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Enum
{

    public enum SpecialWordsEnum
    {
       
        LeftBracket = 34,  //[StringValue("[")]
        RightBracket = 35, //[StringValue("]")]
        LeftParentheses = 36,  //[StringValue("(")]
        RightParentheses = 37, //[StringValue(")")]
        Equal = 38,  //[StringValue(":=")] 
        Colon = 39, //[StringValue(":")]
        Comparation = 40, //[StringValue("=")]
        Coma = 46,   //,
        SemiColon = 47,  //;
        Point = 49, //.
        DoublePoints = 50, //:
        DollarSign = 51 //$

    }
}
