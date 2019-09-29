using Core.Enums;
using System;
using System.Collections.Generic;

namespace Core.SyntacticalAnalysis
{
    public static class ParsingMatrixDictionary
    {
        private static IDictionary<NonTerminalEnum, IDictionary<Enum, IList<Enum>>>
        parsingMatrix = new Dictionary<NonTerminalEnum, IDictionary<Enum, IList<Enum>>>
        {
            // 52
            {
                NonTerminalEnum.PROGRAMA,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (52, 1)
                    // PROGRAM|IDENTIFICADOR|;|BLOCO|.
                    {
                        ReservedWordEnum.Program,
                        new List<Enum>
                        {
                            ReservedWordEnum.Program,
                            IdentifierEnum.Identifier,
                            SpecialSymbolEnum.SemiColon,
                            NonTerminalEnum.BLOCO,
                            SpecialSymbolEnum.Point
                        }
                    }
                }
            },
            // 53
            {
                NonTerminalEnum.BLOCO,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (53, 2)
                    // DCLROT|DCLCONST|DCLVAR|DCLPROC|CORPO
                    {
                        ReservedWordEnum.Label,
                        new List<Enum>
                        {
                            NonTerminalEnum.DCLROT,
                            NonTerminalEnum.DCLCONST,
                            NonTerminalEnum.DCLVAR,
                            NonTerminalEnum.DCLPROC,
                            NonTerminalEnum.CORPO
                        }
                    },
                    // (53, 3)
                    // DCLROT|DCLCONST|DCLVAR|DCLPROC|CORPO
                    {
                        ReservedWordEnum.Const,
                        new List<Enum>
                        {
                            NonTerminalEnum.DCLROT,
                            NonTerminalEnum.DCLCONST,
                            NonTerminalEnum.DCLVAR,
                            NonTerminalEnum.DCLPROC,
                            NonTerminalEnum.CORPO
                        }
                    },
                    // (53, 4)
                    // DCLROT|DCLCONST|DCLVAR|DCLPROC|CORPO
                    {
                        ReservedWordEnum.Var,
                        new List<Enum>
                        {
                            NonTerminalEnum.DCLROT,
                            NonTerminalEnum.DCLCONST,
                            NonTerminalEnum.DCLVAR,
                            NonTerminalEnum.DCLPROC,
                            NonTerminalEnum.CORPO
                        }
                    },
                    // (53, 5)
                    // DCLROT|DCLCONST|DCLVAR|DCLPROC|CORPO
                    {
                        ReservedWordEnum.Procedure,
                        new List<Enum>
                        {
                            NonTerminalEnum.DCLROT,
                            NonTerminalEnum.DCLCONST,
                            NonTerminalEnum.DCLVAR,
                            NonTerminalEnum.DCLPROC,
                            NonTerminalEnum.CORPO
                        }
                    },
                    // (53, 6)
                    // DCLROT|DCLCONST|DCLVAR|DCLPROC|CORPO
                    {
                        ReservedWordEnum.Begin,
                        new List<Enum>
                        {
                            NonTerminalEnum.DCLROT,
                            NonTerminalEnum.DCLCONST,
                            NonTerminalEnum.DCLVAR,
                            NonTerminalEnum.DCLPROC,
                            NonTerminalEnum.CORPO
                        }
                    }
                }
            },
            // 54
            {
                NonTerminalEnum.DCLROT,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (54, 2)
                    // LABEL|LID|;
                    {
                        ReservedWordEnum.Label,
                        new List<Enum>
                        {
                            ReservedWordEnum.Label,
                            NonTerminalEnum.LID,
                            SpecialSymbolEnum.SemiColon
                        }
                    },
                    // (54, 3)
                    // NULL
                    {
                        ReservedWordEnum.Const,
                        null
                    },
                    // (54, 4)
                    // NULL
                    {
                        ReservedWordEnum.Var,
                        null
                    }
                    ,
                    // (54, 5)
                    // NULL
                    {
                        ReservedWordEnum.Procedure,
                        null
                    }
                    ,
                    // (54, 6)
                    // NULL
                    {
                        ReservedWordEnum.Begin,
                        null
                    }
                }
            },
            // 55
            {
                NonTerminalEnum.LID,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (55, 25)
                    // IDENTIFICADOR|REPIDENT
                    {
                        IdentifierEnum.Identifier,
                        new List<Enum>
                        {
                            IdentifierEnum.Identifier,
                            NonTerminalEnum.REPIDENT
                        }
                    }
                }
            },
            // 56
            {
                NonTerminalEnum.REPIDENT,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (56, 39)
                    // NULL
                    {
                        SpecialSymbolEnum.Colon,
                        null
                    },
                    // (56, 46)
                    // ,|IDENTIFICADOR|REPIDENT
                    {
                        SpecialSymbolEnum.Coma,
                        new List<Enum>
                        {
                            SpecialSymbolEnum.Coma,
                            IdentifierEnum.Identifier,
                            NonTerminalEnum.REPIDENT
                        }
                    },
                    // (56, 47)
                    // NULL
                    {
                        SpecialSymbolEnum.SemiColon,
                        null
                    }
                }
            },
            // 57
            {
                NonTerminalEnum.DCLCONST,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (57, 3)
                    // CONST|IDENTIFICADOR|=|INTEIRO|;|LDCONST
                    {
                        ReservedWordEnum.Const,
                        new List<Enum>
                        {
                            ReservedWordEnum.Const,
                            IdentifierEnum.Identifier,
                            SpecialSymbolEnum.Equal,
                            NumberEnum.Integer,
                            SpecialSymbolEnum.SemiColon,
                            NonTerminalEnum.LDCONST
                        }
                    },
                    // (57, 4)
                    // NULL
                    {
                        ReservedWordEnum.Var,
                        null
                    },
                    // (57, 5)
                    // NULL
                    {
                        ReservedWordEnum.Procedure,
                        null
                    },
                    // (57, 6)
                    // NULL
                    {
                        ReservedWordEnum.Begin,
                        null
                    }
                }
            },
            // 58
            {
                NonTerminalEnum.LDCONST,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (58, 4)
                    // NULL
                    {
                        ReservedWordEnum.Var,
                        null
                    },
                    // (58, 5)
                    // NULL
                    {
                        ReservedWordEnum.Procedure,
                        null
                    },
                    // (58, 6)
                    // NULL
                    {
                        ReservedWordEnum.Begin,
                        null
                    },
                    // (58, 25)
                    // IDENTIFICADOR|=|INTEIRO|;|LDCONST
                    {
                        IdentifierEnum.Identifier,
                        new List<Enum>
                        {
                            IdentifierEnum.Identifier,
                            SpecialSymbolEnum.Equal,
                            NumberEnum.Integer,
                            SpecialSymbolEnum.SemiColon,
                            NonTerminalEnum.LDCONST
                        }
                    }
                }
            },
            // 59
            {
                NonTerminalEnum.DCLVAR,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (59, 4)
                    // VAR|LID|:|TIPO|;|LDVAR
                    {
                        ReservedWordEnum.Var,
                        new List<Enum>
                        {
                            ReservedWordEnum.Var,
                            NonTerminalEnum.LID,
                            SpecialSymbolEnum.Colon,
                            NonTerminalEnum.TIPO,
                            SpecialSymbolEnum.SemiColon,
                            NonTerminalEnum.LDVAR
                        }
                    },
                    // (59, 5)
                    // NULL
                    {
                        ReservedWordEnum.Procedure,
                        null
                    },
                    // (59, 6)
                    // NULL
                    {
                        ReservedWordEnum.Begin,
                        null
                    }
                }
            },
            // 60
            {
                NonTerminalEnum.LDVAR,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (60, 5)
                    // NULL
                    {
                        ReservedWordEnum.Procedure,
                        null
                    },
                    // (60, 6)
                    // NULL
                    {
                        ReservedWordEnum.Begin,
                        null
                    },
                    // (60, 25)
                    // LID|:|TIPO|;|LDVAR
                    {
                        IdentifierEnum.Identifier,
                        new List<Enum>
                        {
                            NonTerminalEnum.LID,
                            SpecialSymbolEnum.Colon,
                            NonTerminalEnum.TIPO,
                            SpecialSymbolEnum.SemiColon,
                            NonTerminalEnum.LDVAR
                        }
                    }
                }
            },
            // 61
            {
                NonTerminalEnum.TIPO,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (61, 8)
                    // INTEGER
                    {
                        ReservedWordEnum.Integer,
                        new List<Enum>
                        {
                            ReservedWordEnum.Integer
                        }
                    },
                    // (61, 9)
                    // ARRAY|[|INTEIRO|..|INTEIRO|]|OF|INTEGER
                    {
                        ReservedWordEnum.Array,
                        new List<Enum>
                        {
                            ReservedWordEnum.Array,
                            SpecialSymbolEnum.LeftBracket,
                            NumberEnum.Integer,
                            SpecialSymbolEnum.DoublePoints,
                            NumberEnum.Integer,
                            SpecialSymbolEnum.RightBracket,
                            ReservedWordEnum.Of,
                            ReservedWordEnum.Integer
                        }
                    }
                }
            },
            // 62
            {
                NonTerminalEnum.DCLPROC,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (62, 5)
                    // PROCEDURE|IDENTIFICADOR|DEFPAR|;|BLOCO|;|DCLPROC
                    {
                        ReservedWordEnum.Procedure,
                        new List<Enum>
                        {
                            ReservedWordEnum.Procedure,
                            IdentifierEnum.Identifier,
                            NonTerminalEnum.DEFPAR,
                            SpecialSymbolEnum.SemiColon,
                            NonTerminalEnum.BLOCO,
                            SpecialSymbolEnum.SemiColon,
                            NonTerminalEnum.DCLPROC
                        }
                    },
                    // (62, 6)
                    // NULL
                    {
                        ReservedWordEnum.Begin,
                        null
                    }
                }
            },
            // 63
            {
                NonTerminalEnum.DEFPAR,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (63, 36)
                    // (|LID|:|INTEGER|)
                    {
                        SpecialSymbolEnum.LeftParentheses,
                        new List<Enum>
                        {
                            SpecialSymbolEnum.LeftParentheses,
                            NonTerminalEnum.LID,
                            SpecialSymbolEnum.Colon,
                            ReservedWordEnum.Integer,
                            SpecialSymbolEnum.RightParentheses
                        }
                    },
                    // (63, 39)
                    // NULL
                    {
                        SpecialSymbolEnum.Colon,
                        null
                    }
                }
            },
            // 64
            {
                NonTerminalEnum.CORPO,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (64, 6)
                    // BEGIN|COMANDO|REPCOMANDO|END
                    {
                        ReservedWordEnum.Begin,
                        new List<Enum>
                        {
                            ReservedWordEnum.Begin,
                            NonTerminalEnum.COMANDO,
                            NonTerminalEnum.REPCOMANDO,
                            ReservedWordEnum.End
                        }
                    }
                }
            },
            // 65
            {
                NonTerminalEnum.REPCOMANDO,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (65, 7)
                    // NULL
                    {
                        ReservedWordEnum.End,
                        null
                    },
                    // (65, 47)
                    // ;|COMANDO|REPCOMANDO
                    {
                        SpecialSymbolEnum.SemiColon,
                        new List<Enum>
                        {
                            SpecialSymbolEnum.SemiColon,
                            NonTerminalEnum.COMANDO,
                            NonTerminalEnum.REPCOMANDO
                        }
                    }
                }
            },
            // 66
            {
                NonTerminalEnum.COMANDO,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (66, 6)
                    // CORPO
                    {
                        ReservedWordEnum.Begin,
                        new List<Enum>
                        {
                            NonTerminalEnum.CORPO
                        }
                    },
                    // (66, 7)
                    // NULL
                    {
                        ReservedWordEnum.End,
                        null
                    },
                    // (66, 11)
                    // CALL|IDENTIFICADOR|PARAMETROS
                    {
                        ReservedWordEnum.Call,
                        new List<Enum>
                        {
                            ReservedWordEnum.Call,
                            IdentifierEnum.Identifier,
                            NonTerminalEnum.PARAMETROS
                        }
                    },
                    // (66, 12)
                    // GOTO|IDENTIFICADOR
                    {
                        ReservedWordEnum.Goto,
                        new List<Enum>
                        {
                            ReservedWordEnum.Goto,
                            IdentifierEnum.Identifier
                        }
                    },
                    // (66, 13)
                    // IF|EXPRESSAO|THEN|COMANDO|ELSEPARTE
                    {
                        ReservedWordEnum.If,
                        new List<Enum>
                        {
                            ReservedWordEnum.If,
                            NonTerminalEnum.EXPRESSAO,
                            ReservedWordEnum.Then,
                            NonTerminalEnum.COMANDO,
                            NonTerminalEnum.ELSEPARTE
                        }
                    },
                    // (66, 15)
                    // NULL
                    {
                        ReservedWordEnum.Else,
                        null
                    },
                    // (66, 16)
                    // WHILE|EXPRESSAO|DO|COMANDO
                    {
                        ReservedWordEnum.While,
                        new List<Enum>
                        {
                            ReservedWordEnum.While,
                            NonTerminalEnum.EXPRESSAO,
                            ReservedWordEnum.Do,
                            NonTerminalEnum.COMANDO
                        }
                    },
                    // (66, 18)
                    // REPEAT|COMANDO|UNTIL|EXPRESSAO
                    {
                        ReservedWordEnum.Repeat,
                        new List<Enum>
                        {
                            ReservedWordEnum.Repeat,
                            NonTerminalEnum.COMANDO,
                            ReservedWordEnum.Until,
                            NonTerminalEnum.EXPRESSAO
                        }
                    },
                    // (66, 19)
                    // NULL
                    {
                        ReservedWordEnum.Until,
                        null
                    },
                    // (66, 20)
                    // READLN|(|VARIAVEL|REPVARIAVEL|)
                    {
                        ReservedWordEnum.Readln,
                        new List<Enum>
                        {
                            ReservedWordEnum.Readln,
                            SpecialSymbolEnum.LeftParentheses,
                            NonTerminalEnum.VARIAVEL,
                            NonTerminalEnum.REPVARIAVEL,
                            SpecialSymbolEnum.RightParentheses
                        }
                    },
                    // (66, 21)
                    // WRITELN|(|ITEMSAIDA|REPITEM|)
                    {
                        ReservedWordEnum.Writeln,
                        new List<Enum>
                        {
                            ReservedWordEnum.Writeln,
                            SpecialSymbolEnum.LeftParentheses,
                            NonTerminalEnum.ITEMSAIDA,
                            NonTerminalEnum.REPITEM,
                            SpecialSymbolEnum.RightParentheses
                        }
                    },
                    // (66, 25)
                    // IDENTIFICADOR|RCOMID
                    {
                        IdentifierEnum.Identifier,
                        new List<Enum>
                        {
                            IdentifierEnum.Identifier,
                            NonTerminalEnum.RCOMID
                        }
                    },
                    // (66, 27)
                    // FOR|IDENTIFICADOR|:=|EXPRESSAO|TO|EXPRESSAO|DO|COMANDO
                    {
                        ReservedWordEnum.For,
                        new List<Enum>
                        {
                            ReservedWordEnum.For,
                            IdentifierEnum.Identifier,
                            SpecialSymbolEnum.Definition,
                            NonTerminalEnum.EXPRESSAO,
                            ReservedWordEnum.To,
                            NonTerminalEnum.EXPRESSAO,
                            ReservedWordEnum.Do,
                            NonTerminalEnum.COMANDO
                        }
                    },
                    // (66, 29)
                    // CASE|EXPRESSAO|OF|CONDCASE|END
                    {
                        ReservedWordEnum.Case,
                        new List<Enum>
                        {
                            ReservedWordEnum.Case,
                            NonTerminalEnum.EXPRESSAO,
                            ReservedWordEnum.Of,
                            NonTerminalEnum.CONDCASE,
                            ReservedWordEnum.End
                        }
                    },
                    // (66, 47)
                    // NULL
                    {
                        SpecialSymbolEnum.SemiColon,
                        null
                    }
                }
            },
            // 67
            {
                NonTerminalEnum.RCOMID,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (67, 34)
                    // RVAR|:=|EXPRESSAO
                    {
                        SpecialSymbolEnum.LeftBracket,
                        new List<Enum>
                        {
                            NonTerminalEnum.RVAR,
                            SpecialSymbolEnum.Definition,
                            NonTerminalEnum.EXPRESSAO
                        }
                    },
                    // (67, 38)
                    // RVAR|:=|EXPRESSAO
                    {
                        SpecialSymbolEnum.Definition,
                        new List<Enum>
                        {
                            NonTerminalEnum.RVAR,
                            SpecialSymbolEnum.Definition,
                            NonTerminalEnum.EXPRESSAO
                        }
                    },
                    // (67, 39)
                    // :|COMANDO
                    {
                        SpecialSymbolEnum.Colon,
                        new List<Enum>
                        {
                            SpecialSymbolEnum.Colon,
                            NonTerminalEnum.COMANDO
                        }
                    }
                }
            },
            // 68
            {
                NonTerminalEnum.RVAR,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (68, 34)
                    // [|EXPRESSAO|]
                    {
                        SpecialSymbolEnum.LeftBracket,
                        new List<Enum>
                        {
                            SpecialSymbolEnum.LeftBracket,
                            NonTerminalEnum.EXPRESSAO,
                            SpecialSymbolEnum.RightBracket
                        }
                    },
                    // (68, 38)
                    // NULL
                    {
                        SpecialSymbolEnum.Definition,
                        null
                    }
                }
            },
            // 69
            {
                NonTerminalEnum.PARAMETROS,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (69, 7)
                    // NULL
                    {
                        ReservedWordEnum.End,
                        null
                    },
                    // (69, 15)
                    // NULL
                    {
                        ReservedWordEnum.Else,
                        null
                    },
                    // (69, 19)
                    // NULL
                    {
                        ReservedWordEnum.Until,
                        null
                    },
                    // (69, 36)
                    // (|EXPRESSAO|REPPAR|)
                    {
                        SpecialSymbolEnum.LeftParentheses,
                        new List<Enum>
                        {
                            SpecialSymbolEnum.LeftParentheses,
                            NonTerminalEnum.EXPRESSAO,
                            NonTerminalEnum.REPPAR,
                            SpecialSymbolEnum.RightParentheses
                        }
                    },
                    // (69, 47)
                    // NULL
                    {
                        SpecialSymbolEnum.SemiColon,
                        null
                    }
                }
            },
            // 70
            {
                NonTerminalEnum.REPPAR,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (70, 37)
                    // NULL
                    {
                        SpecialSymbolEnum.RightParentheses,
                        null
                    },
                    // (70, 46)
                    // ,|EXPRESSAO|REPPAR
                    {
                        SpecialSymbolEnum.Coma,
                        new List<Enum>
                        {
                            SpecialSymbolEnum.Coma,
                            NonTerminalEnum.EXPRESSAO,
                            NonTerminalEnum.REPPAR
                        }
                    }
                }
            },
            // 71
            {
                NonTerminalEnum.ELSEPARTE,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (71, 7)
                    // NULL
                    {
                        ReservedWordEnum.End,
                        null
                    },
                    // (71, 15)
                    // ELSE|COMANDO
                    {
                        ReservedWordEnum.Else,
                        new List<Enum>
                        {
                            ReservedWordEnum.Else,
                            NonTerminalEnum.COMANDO
                        }
                    },
                    // (71, 19)
                    // NULL
                    {
                        ReservedWordEnum.Until,
                        null
                    },
                    // (71, 47)
                    // NULL
                    {
                        SpecialSymbolEnum.SemiColon,
                        null
                    },
                }
            },
            // 72
            {
                NonTerminalEnum.VARIAVEL,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (72, 25)
                    // IDENTIFICADOR|VARIAVEL1
                    {
                        IdentifierEnum.Identifier,
                        new List<Enum>
                        {
                            IdentifierEnum.Identifier,
                            NonTerminalEnum.VARIAVEL1
                        }
                    },
                }
            },
            // 73
            {
                NonTerminalEnum.VARIAVEL1,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (73, 7)
                    // NULL
                    {
                        ReservedWordEnum.End,
                        null
                    },
                    // (73, 10)
                    // NULL
                    {
                        ReservedWordEnum.Of,
                        null
                    },
                    // (73, 14)
                    // NULL
                    {
                        ReservedWordEnum.Then,
                        null
                    },
                    // (73, 15)
                    // NULL
                    {
                        ReservedWordEnum.Else,
                        null
                    },
                    // (73, 17)
                    // NULL
                    {
                        ReservedWordEnum.Do,
                        null
                    },
                    // (73, 19)
                    // NULL
                    {
                        ReservedWordEnum.Until,
                        null
                    },
                    // (73, 22)
                    // NULL
                    {
                        OperatorEnum.Or,
                        null
                    },
                    // (73, 23)
                    // NULL
                    {
                        OperatorEnum.And,
                        null
                    },
                    // (73, 28)
                    // NULL
                    {
                        ReservedWordEnum.To,
                        null
                    },
                    // (73, 30)
                    // NULL
                    {
                        OperatorEnum.Plus,
                        null
                    },
                    // (73, 31)
                    // NULL
                    {
                        OperatorEnum.Minus,
                        null
                    },
                    // (73, 32)
                    // NULL
                    {
                        OperatorEnum.Mult,
                        null
                    },
                    // (73, 33)
                    // NULL
                    {
                        OperatorEnum.Div,
                        null
                    },
                    // (73, 34)
                    // [|EXPRESSAO|]
                    {
                        SpecialSymbolEnum.LeftBracket,
                        new List<Enum>
                        {
                            SpecialSymbolEnum.LeftBracket,
                            NonTerminalEnum.EXPRESSAO,
                            SpecialSymbolEnum.RightBracket
                        }
                    },
                    // (73, 35)
                    // NULL
                    {
                        SpecialSymbolEnum.RightBracket,
                        null
                    },
                    // (73, 37)
                    // NULL
                    {
                        SpecialSymbolEnum.RightParentheses,
                        null
                    },
                    // (73, 40)
                    // NULL
                    {
                        SpecialSymbolEnum.Equal,
                        null
                    },
                    // (73, 41)
                    // NULL
                    {
                        OperatorEnum.GreaterThan,
                        null
                    },
                    // (73, 42)
                    // NULL
                    {
                        OperatorEnum.GreaterOrEqual,
                        null
                    },
                    // (73, 43)
                    // NULL
                    {
                        OperatorEnum.LessThan,
                        null
                    },
                    // (73, 44)
                    // NULL
                    {
                        OperatorEnum.LessOrEqual,
                        null
                    },
                    // (73, 45)
                    // NULL
                    {
                        OperatorEnum.NotEqual,
                        null
                    },
                    // (73, 46)
                    // NULL
                    {
                        SpecialSymbolEnum.Coma,
                        null
                    },
                    // (73, 47)
                    // NULL
                    {
                        SpecialSymbolEnum.SemiColon,
                        null
                    }
                }
            },
            // 74
            {
                NonTerminalEnum.REPVARIAVEL,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (74, 37)
                    // NULL
                    {
                        SpecialSymbolEnum.RightParentheses,
                        null
                    },
                    // (74, 46)
                    // ,|VARIAVEL|REPVARIAVEL
                    {
                        SpecialSymbolEnum.Coma,
                        new List<Enum>
                        {
                            SpecialSymbolEnum.Coma,
                            NonTerminalEnum.VARIAVEL,
                            NonTerminalEnum.REPVARIAVEL
                        }
                    }
                }
            },
            // 75
            {
                NonTerminalEnum.ITEMSAIDA,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (75, 24)
                    // EXPRESSAO
                    {
                        OperatorEnum.Not,
                        new List<Enum>
                        {
                            NonTerminalEnum.EXPRESSAO
                        }
                    },
                    // (75, 25)
                    // EXPRESSAO
                    {
                        IdentifierEnum.Identifier,
                        new List<Enum>
                        {
                            NonTerminalEnum.EXPRESSAO
                        }
                    },
                    // (75, 26)
                    // EXPRESSAO
                    {
                        NumberEnum.Integer,
                        new List<Enum>
                        {
                            NonTerminalEnum.EXPRESSAO
                        }
                    },
                    // (75, 30)
                    // EXPRESSAO
                    {
                        OperatorEnum.Plus,
                        new List<Enum>
                        {
                            NonTerminalEnum.EXPRESSAO
                        }
                    },
                    // (75, 31)
                    // EXPRESSAO
                    {
                        OperatorEnum.Minus,
                        new List<Enum>
                        {
                             NonTerminalEnum.EXPRESSAO
                        }
                    },
                    // (75, 36)
                    // EXPRESSAO
                    {
                        SpecialSymbolEnum.LeftParentheses,
                        new List<Enum>
                        {
                             NonTerminalEnum.EXPRESSAO
                        }
                    },
                    // (75, 48)
                    // LITERAL
                    {
                        LiteralEnum.Literal,
                        new List<Enum>
                        {
                            LiteralEnum.Literal
                        }
                    }
                }
            },
            // 76
            {
                NonTerminalEnum.REPITEM,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (76, 37)
                    // NULL
                    {
                        SpecialSymbolEnum.RightParentheses,
                        null
                    },
                    // (76, 46)
                    // ,|ITEMSAIDA|REPITEM
                    {
                        SpecialSymbolEnum.Coma,
                        new List<Enum>
                        {
                            SpecialSymbolEnum.Coma,
                            NonTerminalEnum.ITEMSAIDA,
                            NonTerminalEnum.REPITEM
                        }
                    }
                }
            },
            // 77
            {
                NonTerminalEnum.EXPRESSAO,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (77, 24)
                    // EXPSIMP|REPEXPSIMP
                    {
                        OperatorEnum.Not,
                        new List<Enum>
                        {
                            NonTerminalEnum.EXPSIMP,
                            NonTerminalEnum.REPEXPSIMP
                        }
                    },
                    // (77, 25)
                    // EXPSIMP|REPEXPSIMP
                    {
                        IdentifierEnum.Identifier,
                        new List<Enum>
                        {
                            NonTerminalEnum.EXPSIMP,
                            NonTerminalEnum.REPEXPSIMP
                        }
                    },
                    // (77, 26)
                    // EXPSIMP|REPEXPSIMP
                    {
                        NumberEnum.Integer,
                        new List<Enum>
                        {
                            NonTerminalEnum.EXPSIMP,
                            NonTerminalEnum.REPEXPSIMP
                        }
                    },
                    // (77, 30)
                    // EXPSIMP|REPEXPSIMP
                    {
                        OperatorEnum.Plus,
                        new List<Enum>
                        {
                            NonTerminalEnum.EXPSIMP,
                            NonTerminalEnum.REPEXPSIMP
                        }
                    },
                    // (77, 31)
                    // EXPSIMP|REPEXPSIMP
                    {
                        OperatorEnum.Minus,
                        new List<Enum>
                        {
                            NonTerminalEnum.EXPSIMP,
                            NonTerminalEnum.REPEXPSIMP
                        }
                    },
                    // (77, 36)
                    // EXPSIMP|REPEXPSIMP
                    {
                        SpecialSymbolEnum.LeftParentheses,
                        new List<Enum>
                        {
                            NonTerminalEnum.EXPSIMP,
                            NonTerminalEnum.REPEXPSIMP
                        }
                    }
                }
            },
            // 78
            {
                NonTerminalEnum.REPEXPSIMP,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (78, 7)
                    // NULL
                    {
                        ReservedWordEnum.End,
                        null
                    },
                    // (78, 10)
                    // NULL
                    {
                        ReservedWordEnum.Of,
                        null
                    },
                    // (78, 14)
                    // NULL
                    {
                        ReservedWordEnum.Then,
                        null
                    },
                    // (78, 15)
                    // NULL
                    {
                        ReservedWordEnum.Else,
                        null
                    },
                    // (78, 17)
                    // NULL
                    {
                        ReservedWordEnum.Do,
                        null
                    },
                    // (78, 19)
                    // NULL
                    {
                        ReservedWordEnum.Until,
                        null
                    },
                    // (78, 28)
                    // NULL
                    {
                        ReservedWordEnum.To,
                        null
                    },
                    // (78, 35)
                    // NULL
                    {
                        SpecialSymbolEnum.RightBracket,
                        null
                    },
                    // (78, 37)
                    // NULL
                    {
                        SpecialSymbolEnum.RightParentheses,
                        null
                    },
                    // (78, 40)
                    // =|EXPSIMP
                    {
                        SpecialSymbolEnum.Equal,
                        new List<Enum>
                        {
                            SpecialSymbolEnum.Equal,
                            NonTerminalEnum.EXPSIMP
                        }
                    },
                    // (78, 41)
                    // >|EXPSIMP
                    {
                        OperatorEnum.GreaterThan,
                        new List<Enum>
                        {
                            OperatorEnum.GreaterThan,
                            NonTerminalEnum.EXPSIMP
                        }
                    },
                    // (78, 42)
                    // >=|EXPSIMP
                    {
                        OperatorEnum.GreaterOrEqual,
                        new List<Enum>
                        {
                            OperatorEnum.GreaterOrEqual,
                            NonTerminalEnum.EXPSIMP
                        }
                    },
                    // (78, 43)
                    //<|EXPSIMP
                    {
                        OperatorEnum.LessThan,
                        new List<Enum>
                        {
                            OperatorEnum.LessThan,
                            NonTerminalEnum.EXPSIMP
                        }
                    },
                    // (78, 44)
                    // <=|EXPSIMP
                    {
                        OperatorEnum.LessOrEqual,
                        new List<Enum>
                        {
                            OperatorEnum.LessOrEqual,
                            NonTerminalEnum.EXPSIMP
                        }
                    },
                    // (78, 45)
                    // <>|EXPSIMP
                    {
                        OperatorEnum.NotEqual,
                        new List<Enum>
                        {
                            OperatorEnum.NotEqual,
                            NonTerminalEnum.EXPSIMP
                        }
                    },
                    // (78, 46)
                    // NULL
                    {
                        SpecialSymbolEnum.Coma,
                        null
                    },
                    // (78, 47)
                    // NULL
                    {
                        SpecialSymbolEnum.SemiColon,
                        null
                    }
                }
            },
            // 79
            {
                NonTerminalEnum.EXPSIMP,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (79, 24)
                    // TERMO|REPEXP
                    {
                        OperatorEnum.Not,
                        new List<Enum>
                        {
                            NonTerminalEnum.TERMO,
                            NonTerminalEnum.REPEXP
                        }
                    },
                    // (79, 25)
                    // TERMO|REPEXP
                    {
                        IdentifierEnum.Identifier,
                        new List<Enum>
                        {
                            NonTerminalEnum.TERMO,
                            NonTerminalEnum.REPEXP
                        }
                    },
                    // (79, 26)
                    // TERMO|REPEXP
                    {
                        NumberEnum.Integer,
                        new List<Enum>
                        {
                            NonTerminalEnum.TERMO,
                            NonTerminalEnum.REPEXP
                        }
                    },
                    // (79, 30)
                    // +|TERMO|REPEXP
                    {
                        OperatorEnum.Plus,
                        new List<Enum>
                        {
                            OperatorEnum.Plus,
                            NonTerminalEnum.TERMO,
                            NonTerminalEnum.REPEXP
                        }
                    },
                    // (79, 31)
                    // -|TERMO|REPEXP
                    {
                        OperatorEnum.Minus,
                        new List<Enum>
                        {
                            OperatorEnum.Minus,
                            NonTerminalEnum.TERMO,
                            NonTerminalEnum.REPEXP
                        }
                    },
                    // (79, 36)
                    // TERMO|REPEXP
                    {
                        SpecialSymbolEnum.LeftParentheses,
                        new List<Enum>
                        {
                            NonTerminalEnum.TERMO,
                            NonTerminalEnum.REPEXP
                        }
                    }
                }
            },
            // 80
            {
                NonTerminalEnum.REPEXP,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (80, 7)
                    // NULL
                    {
                        ReservedWordEnum.End,
                        null
                    },
                    // (80, 10)
                    // NULL
                    {
                        ReservedWordEnum.Of,
                        null
                    },
                    // (80, 14)
                    // NULL
                    {
                        ReservedWordEnum.Then,
                        null
                    },
                    // (80, 15)
                    // NULL
                    {
                        ReservedWordEnum.Else,
                        null
                    },
                    // (80, 17)
                    // NULL
                    {
                        ReservedWordEnum.Do,
                        null
                    },
                    // (80, 19)
                    // NULL
                    {
                        ReservedWordEnum.Until,
                        null
                    },
                    // (80, 22)
                    // OR|TERMO|REPEXP
                    {
                        OperatorEnum.Or,
                        new List<Enum>
                        {
                            OperatorEnum.Or,
                            NonTerminalEnum.TERMO,
                            NonTerminalEnum.REPEXP
                        }
                    },
                    // (80, 28)
                    // NULL
                    {
                        ReservedWordEnum.To,
                        null
                    },
                    // (80, 30)
                    // +|TERMO|REPEXP
                    {
                        OperatorEnum.Plus,
                        new List<Enum>
                        {
                            OperatorEnum.Plus,
                            NonTerminalEnum.TERMO,
                            NonTerminalEnum.REPEXP
                        }
                    },
                    // (80, 31)
                    // -|TERMO|REPEXP
                    {
                        OperatorEnum.Minus,
                        new List<Enum>
                        {
                            OperatorEnum.Minus,
                            NonTerminalEnum.TERMO,
                            NonTerminalEnum.REPEXP
                        }
                    },
                    // (80, 35)
                    // NULL
                    {
                        SpecialSymbolEnum.RightBracket,
                        null
                    },
                    // (80, 37)
                    // NULL
                    {
                        SpecialSymbolEnum.RightParentheses,
                        null
                    },
                    // (80, 40)
                    // NULL
                    {
                        SpecialSymbolEnum.Equal,
                        null
                    },
                    // (80, 41)
                    // NULL
                    {
                        OperatorEnum.GreaterThan,
                        null
                    },
                    // (80, 42)
                    // NULL
                    {
                        OperatorEnum.GreaterOrEqual,
                        null
                    },
                    // (80, 43)
                    // NULL
                    {
                        OperatorEnum.LessThan,
                        null
                    },
                    // (80, 44)
                    // NULL
                    {
                        OperatorEnum.LessOrEqual,
                        null
                    },
                    // (80, 45)
                    // NULL
                    {
                        OperatorEnum.NotEqual,
                        null
                    },
                    // (80, 46)
                    // NULL
                    {
                        SpecialSymbolEnum.Coma,
                        null
                    },
                    // (80, 47)
                    // NULL
                    {
                        SpecialSymbolEnum.SemiColon,
                        null
                    }
                }
            },
            // 81
            {
                NonTerminalEnum.TERMO,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (81, 24)
                    // FATOR|REPTERMO
                    {
                        OperatorEnum.Not,
                        new List<Enum>
                        {
                            NonTerminalEnum.FATOR,
                            NonTerminalEnum.REPTERMO
                        }
                    },
                    // (81, 25)
                    // FATOR|REPTERMO
                    {
                        IdentifierEnum.Identifier,
                        new List<Enum>
                        {
                            NonTerminalEnum.FATOR,
                            NonTerminalEnum.REPTERMO
                        }
                    },
                    // (81, 26)
                    // FATOR|REPTERMO
                    {
                        NumberEnum.Integer,
                        new List<Enum>
                        {
                            NonTerminalEnum.FATOR,
                            NonTerminalEnum.REPTERMO
                        }
                    },
                    // (81, 36)
                    // FATOR|REPTERMO
                    {
                        SpecialSymbolEnum.LeftParentheses,
                        new List<Enum>
                        {
                            NonTerminalEnum.FATOR,
                            NonTerminalEnum.REPTERMO
                        }
                    }
                }
            },
            // 82
            {
                NonTerminalEnum.REPTERMO,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (82, 7)
                    // NULL
                    {
                        ReservedWordEnum.End,
                        null
                    },
                    // (82, 10)
                    // NULL
                    {
                        ReservedWordEnum.Of,
                        null
                    },
                    // (82, 14)
                    // NULL
                    {
                        ReservedWordEnum.Then,
                        null
                    },
                    // (82, 15)
                    // NULL
                    {
                        ReservedWordEnum.Else,
                        null
                    },
                    // (82, 17)
                    // NULL
                    {
                        ReservedWordEnum.Do,
                        null
                    },
                    // (82, 19)
                    // NULL
                    {
                        ReservedWordEnum.Until,
                        null
                    },
                    // (82, 22)
                    // NULL
                    {
                        OperatorEnum.Or,
                        null
                    },
                    // (82, 23)
                    // AND|FATOR|REPTERMO
                    {
                        OperatorEnum.And,
                        new List<Enum>
                        {
                            OperatorEnum.And,
                            NonTerminalEnum.FATOR,
                            NonTerminalEnum.REPTERMO
                        }
                    },
                    // (82, 28)
                    // NULL
                    {
                        ReservedWordEnum.To,
                        null
                    },
                    // (82, 30)
                    // NULL
                    {
                        OperatorEnum.Plus,
                        null
                    },
                    // (82, 31)
                    // NULL
                    {
                        OperatorEnum.Minus,
                        null
                    },
                    // (82, 32)
                    // *|FATOR|REPTERMO
                    {
                        OperatorEnum.Mult,
                        new List<Enum>
                        {
                            OperatorEnum.Mult,
                            NonTerminalEnum.FATOR,
                            NonTerminalEnum.REPTERMO
                        }
                    },
                    // (82, 33)
                    // /|FATOR|REPTERMO
                    {
                        OperatorEnum.Div,
                        new List<Enum>
                        {
                            OperatorEnum.Div,
                            NonTerminalEnum.FATOR,
                            NonTerminalEnum.REPTERMO
                        }
                    },
                    // (82, 35)
                    // NULL
                    {
                        SpecialSymbolEnum.RightBracket,
                        null
                    },
                    // (82, 37)
                    // NULL
                    {
                        SpecialSymbolEnum.RightParentheses,
                        null
                    },
                    // (82, 40)
                    // NULL
                    {
                        SpecialSymbolEnum.Equal,
                        null
                    },
                    // (82, 41)
                    // NULL
                    {
                        OperatorEnum.GreaterThan,
                        null
                    },
                    // (82, 42)
                    // NULL
                    {
                        OperatorEnum.GreaterOrEqual,
                        null
                    },
                    // (82, 43)
                    // NULL
                    {
                        OperatorEnum.LessThan,
                        null
                    },
                    // (82, 44)
                    // NULL
                    {
                        OperatorEnum.LessOrEqual,
                        null
                    },
                    // (82, 45)
                    // NULL
                    {
                        OperatorEnum.NotEqual,
                        null
                    },
                    // (82, 46)
                    // NULL
                    {
                        SpecialSymbolEnum.Coma,
                        null
                    },
                    // (82, 47)
                    // NULL
                    {
                        SpecialSymbolEnum.SemiColon,
                        null
                    }
                }
            },
            // 83
            {
                NonTerminalEnum.FATOR,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (83, 24)
                    // NOT|FATOR
                    {
                        OperatorEnum.Not,
                        new List<Enum>
                        {
                            OperatorEnum.Not,
                            NonTerminalEnum.FATOR
                        }
                    },
                    // (83, 25)
                    // VARIAVEL
                    {
                        IdentifierEnum.Identifier,
                        new List<Enum>
                        {
                            NonTerminalEnum.VARIAVEL
                        }
                    },
                    // (83, 26)
                    // INTEIRO
                    {
                        NumberEnum.Integer,
                        new List<Enum>
                        {
                            NumberEnum.Integer
                        }
                    },
                    // (83, 36)
                    // (|EXPRESSAO|)
                    {
                        SpecialSymbolEnum.LeftParentheses,
                        new List<Enum>
                        {
                            SpecialSymbolEnum.LeftParentheses,
                            NonTerminalEnum.EXPRESSAO,
                            SpecialSymbolEnum.RightParentheses
                        }
                    }
                }
            },
            // 84
            {
                NonTerminalEnum.CONDCASE,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (84, 26)
                    // INTEIRO|RPINTEIRO|:|COMANDO|CONTCASE
                    {
                        NumberEnum.Integer,
                        new List<Enum>
                        {
                            NumberEnum.Integer,
                            NonTerminalEnum.RPINTEIRO,
                            SpecialSymbolEnum.Colon,
                            NonTerminalEnum.COMANDO,
                            NonTerminalEnum.CONTCASE
                        }
                    }
                }
            },
            // 85
            {
                NonTerminalEnum.CONTCASE,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (85, 7)
                    // NULL
                    {
                        ReservedWordEnum.End,
                        null
                    },
                    // (85, 47)
                    // ;|CONDCASE
                    {
                        SpecialSymbolEnum.SemiColon,
                        new List<Enum>
                        {
                            SpecialSymbolEnum.SemiColon,
                            NonTerminalEnum.CONDCASE
                        }
                    }
                }
            },
            // 86
            {
                NonTerminalEnum.RPINTEIRO,
                new Dictionary<Enum, IList<Enum>>
                {
                    // (86, 39)
                    // NULL
                    {
                        SpecialSymbolEnum.Colon,
                        null
                    },
                    // (86, 46)
                    // ,|INTEIRO|RPINTEIRO
                    {
                        SpecialSymbolEnum.Coma,
                        new List<Enum>
                        {
                            SpecialSymbolEnum.Coma,
                            NumberEnum.Integer,
                            NonTerminalEnum.RPINTEIRO
                        }
                    }
                }
            },
            // 87
            {
                NonTerminalEnum.SEMEFEITO,
                new Dictionary<Enum, IList<Enum>>
                {
                }
            }
        };

        public static IDictionary<NonTerminalEnum, IDictionary<Enum, IList<Enum>>> 
            Get()
        {
            return parsingMatrix;
        }
    }
}
