using Core.Enum;
using System.Collections.Generic;

namespace Core.SyntacticalAnalysis
{
    public static class ParsingMatrixDictionary
    {
        private static IDictionary<NonTerminalEnum, IDictionary<System.Enum, IList<System.Enum>>>
        parsingMatrix = new Dictionary<NonTerminalEnum, IDictionary<System.Enum, IList<System.Enum>>>
        {
            // 52
            {
                NonTerminalEnum.PROGRAMA,
                new Dictionary<System.Enum, IList<System.Enum>>
                {
                    // (52, 1)
                    {
                        ReservedWordEnum.Program,
                        new List<System.Enum>
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
                new Dictionary<System.Enum, IList<System.Enum>>
                {
                    // (53, 2)
                    {
                        ReservedWordEnum.Label,
                        new List<System.Enum>
                        {
                            NonTerminalEnum.DCLROT,
                            NonTerminalEnum.DCLCONST,
                            NonTerminalEnum.DCLVAR,
                            NonTerminalEnum.DCLPROC,
                            NonTerminalEnum.CORPO
                        }
                    },
                    // (53, 3)
                    {
                        ReservedWordEnum.Cons,
                        new List<System.Enum>
                        {
                            NonTerminalEnum.DCLROT,
                            NonTerminalEnum.DCLCONST,
                            NonTerminalEnum.DCLVAR,
                            NonTerminalEnum.DCLPROC,
                            NonTerminalEnum.CORPO
                        }
                    },
                    // (53, 4)
                    {
                        ReservedWordEnum.Var,
                        new List<System.Enum>
                        {
                            NonTerminalEnum.DCLROT,
                            NonTerminalEnum.DCLCONST,
                            NonTerminalEnum.DCLVAR,
                            NonTerminalEnum.DCLPROC,
                            NonTerminalEnum.CORPO
                        }
                    },
                    // (53, 5)
                    {
                        ReservedWordEnum.Procedure,
                        new List<System.Enum>
                        {
                            NonTerminalEnum.DCLROT,
                            NonTerminalEnum.DCLCONST,
                            NonTerminalEnum.DCLVAR,
                            NonTerminalEnum.DCLPROC,
                            NonTerminalEnum.CORPO
                        }
                    },
                    // (53, 6)
                    {
                        ReservedWordEnum.Begin,
                        new List<System.Enum>
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
                new Dictionary<System.Enum, IList<System.Enum>>
                {
                    // (54, 2)
                    {
                        ReservedWordEnum.Label,
                        new List<System.Enum>
                        {
                            ReservedWordEnum.Label,
                            NonTerminalEnum.LID,
                            SpecialSymbolEnum.SemiColon
                        }
                    },
                    // (54, 3)
                    {
                        ReservedWordEnum.Cons,
                        null
                    },
                    // (54, 4)
                    {
                        ReservedWordEnum.Var,
                        null
                    }
                    ,
                    // (54, 5)
                    {
                        ReservedWordEnum.Procedure,
                        null
                    }
                    ,
                    // (54, 6)
                    {
                        ReservedWordEnum.Begin,
                        null
                    }
                }
            },
            // 55
            {
                NonTerminalEnum.LID,
                new Dictionary<System.Enum, IList<System.Enum>>
                {
                    // (55, 25)
                    {
                        IdentifierEnum.Identifier,
                        new List<System.Enum>
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
                new Dictionary<System.Enum, IList<System.Enum>>
                {
                    // (56, 39)
                    {
                        SpecialSymbolEnum.Colon,
                        null
                    },
                    // (56, 46)
                    {
                        SpecialSymbolEnum.Coma,
                        new List<System.Enum>
                        {
                            SpecialSymbolEnum.Coma,
                            IdentifierEnum.Identifier,
                            NonTerminalEnum.REPIDENT
                        }
                    },
                    // (56, 47)
                    {
                        SpecialSymbolEnum.SemiColon,
                        null
                    }
                }
            },
        };

        public static IDictionary<NonTerminalEnum, IDictionary<System.Enum, IList<System.Enum>>> Get()
        {
            return parsingMatrix;
        }
    }
}
