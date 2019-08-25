using System;
using System.Collections.Generic;
using System.Text;

namespace CompilerCore.Enums
{

       public enum ReservedWords
        {
            Program = 1,
            Label,
            Const,
            Var,
            Procedure,
            Begin,
            End,
            Integer,
            Array,
            Of,
            Call,
            Goto,
            If,
            Then,
            Else,
            While,
            Do,
            Repeat,
            Until,
            Readln,
            Writeln,
            Or,
            And,
            Not,
            Identificador,
            Inteiro,
            For,
            To,
            Case,
            Literal = 48
        }

       public enum SpecialCharacters
        {
            [StringValue("+")]
            Plus = 30,

            [StringValue("-")]
            Minus = 31,

            [StringValue("*")]
            Mult = 32,

            [StringValue("/")]
            Div = 33,

            [StringValue("[")]
            LeftBracket = 34,

            [StringValue("]")]
            RightBracket = 35,

            [StringValue("(")]
            LeftParentheses = 36,

            [StringValue(")")]
            RightParentheses = 37,

            [StringValue(":=")]
            Equal = 38,

            [StringValue(":")]
            TwoDots = 39,

            [StringValue("=")]
            Comparation = 40,

            [StringValue(">")]
            BiggerThan = 41,

            [StringValue(">=")]
            BiggerOrEqual = 42,

            [StringValue("<")]
            LessThan = 43,

            [StringValue("<=")]
            LessOrEqual = 44,

            [StringValue("<>")]
            a = 45,

            [StringValue(",")]
            Coma = 46,

            [StringValue(";")]
            DotAndComa = 47,

            [StringValue(".")]
            Dot = 49,

            [StringValue("..")]
            DotDot = 50,

            [StringValue("$")]
            Sifer = 51,

    }

    }

