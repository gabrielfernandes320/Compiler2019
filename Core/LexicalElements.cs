using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    class LexicalElements
    {
        List<string> ReservedWords { get; set; } = new List<string>(){"AND" , "ARRAY" , "BEGIN" , "CALL" , "CASE" , "CONST" , "DO" , "ELSE" , "END" , "FOR" ,
            "GOTO", "IF", "INTEGER", "LABEL", "NOT", "OF", "OR", "PROCEDURE",
            "PROGRAM", "READLN", "REPEAT", "THEN", "TO", "UNTIL", "VAR", "WHILE",
            "WRITELN" };

        List<string> Operators { get; set; } = new List<string>()
        {
            "NOT",
            "*",
            "/",
            "AND",
            "+",
            "-",
            "OR",
            "<",
            ">",
            "=",
            "<=",
            ">=",
            "<>"
        };

        public int MyProperty { get; set; }
        public LexicalElements()
        {
        }

        public LexicalElements(List<string> reservedWords, List<string> operators)
        {
            ReservedWords = reservedWords;
            Operators = operators;
        }
    }

}
