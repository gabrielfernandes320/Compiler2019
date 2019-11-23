using Core.Enums;
using Core.Exceptions;
using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.SemanticAnalysis;

namespace Core.SyntacticalAnalysis
{
    public class SyntacticalAnalyzer
    {
        private readonly IDictionary<NonTerminalEnum, IDictionary<Enum, IList<Enum>>> parsingMatrix;
        private Stack<Token> tokensStack = new Stack<Token>();
        private Stack<DerivedItem> expansionStack = new Stack<DerivedItem>();
        private SemanticAnalyzer semanticAnalyzer = new SemanticAnalyzer();
        private int currentLevel = 0;

        public SyntacticalAnalyzer(IList<Token> tokens)
        {
            parsingMatrix = ParsingMatrixDictionary.Get();
            tokensStack = CreateTokensStack(tokens);

            expansionStack.Push(CreateDerivedItem(NonTerminalEnum.PROGRAMA));
        }

        public IEnumerable<SyntacticalAnalysisProcessing> Start()
        {
            //while (expansionStack.Count > 0 && tokensStack.Count > 0)
            while (expansionStack.Count > 0)
            {
                Enum x = expansionStack.Peek().Enumeration; // X

                // If tokens is empty
                if (tokensStack.Count <= 0)
                {
                    throw new SyntacticalException("Sintaxe inválida. Não foi possível encontrar[" + x + "(" + x.GetValue<int>() + ")] na tabela de tokens");
                }

                Token currentToken = tokensStack.Peek();

                Enum a = currentToken.Type; // a

                bool isNonTerminal = x.OfType<NonTerminalEnum>();

                // If "X" is not a terminal
                if (isNonTerminal)
                {
                    // Find by item "X" in the parsingMatrix
                    if (parsingMatrix.ContainsKey((NonTerminalEnum)x))
                    {
                        IDictionary<Enum, IList<Enum>> parsingItemsFromX = parsingMatrix[(NonTerminalEnum)x];

                        // Find by "a" in the parsingItemsFromX
                        if (parsingItemsFromX.ContainsKey(a))
                        {
                            // Remove "X" from the expansionStack
                            expansionStack.Pop();

                            // Add derivations of (X, a) to expansionStack
                            if (parsingItemsFromX[a] != null)
                            {
                                foreach (Enum enumeration in parsingItemsFromX[a].Reverse())
                                {
                                    expansionStack.Push(CreateDerivedItem(enumeration));
                                }
                            }

                            yield return new SyntacticalAnalysisProcessing
                            {
                                RemovedToken = null,
                                ExpansionStack = expansionStack,
                                LineNumber = currentToken.StartChar.Line
                            };
                        } else
                        {
                            throw new SyntacticalException(GetLineColumnText(currentToken.StartChar) + ": Sintaxe inválida. Não foi possível encontrar [" + x + ", " + a + " (" + x.GetValue<int>() + ", " + a.GetValue<int>() + ")] na tabela de parsing", currentToken.StartChar.Line);
                        }
                    } else
                    {
                        throw new SyntacticalException(GetLineColumnText(currentToken.StartChar) + ": Sintaxe inválida. Não foi possível encontrar [" + x + " (" + x.GetValue<int>() + ")] na tabela de parsing", currentToken.StartChar.Line);
                    }

                    // If "X" is a terminal
                } else {
                    // And "X" is equal "a"
                    if (x.GetType() == a.GetType())
                    {
                        //Set level for semantic analysis
                        SetLevel(currentToken);


                        // Remove both from stack
                        expansionStack.Pop();
                        Token removedToken = tokensStack.Pop();

                        //Make a copy of the original stack
                        var clonedStack = new Stack<Token>(new Stack<Token>(tokensStack));
                        Token nextToken = new Token();
                        if (clonedStack.Count > 0 )
                        {
                            nextToken = clonedStack.Peek();
                        }
                        
                        //Check if is variable declaration
                        if (removedToken.Code == 4 && nextToken.Code == (int)IdentifierEnum.Identifier)
                        {
                            semanticAnalyzer.VariableDeclaration(clonedStack, currentLevel);
                        }

                        //Check if is procedure declaration
                        if (removedToken.Code == (int)ReservedWordEnum.Procedure && nextToken.Code == (int)IdentifierEnum.Identifier)
                        {
                            semanticAnalyzer.ProcedureDeclaration(nextToken, currentLevel);
                        }

                        //Const declaration
                        if (removedToken.Code == (int)ReservedWordEnum.Const && nextToken.Code == (int)IdentifierEnum.Identifier)
                        {
                            semanticAnalyzer.VariableDeclaration(clonedStack, currentLevel);
                        }

                        //Clear in end of procedure
                        if (removedToken.Code == (int)ReservedWordEnum.End && nextToken.Code == (int)SpecialSymbolEnum.SemiColon)
                        {
                            semanticAnalyzer.ClearByLevel(1);
                        }

                        //Check if is label declaration
                        if (removedToken.Code == (int)ReservedWordEnum.Label && nextToken.Code == (int)IdentifierEnum.Identifier)
                        {
                            semanticAnalyzer.LabelDeclaration(clonedStack, currentLevel);
                        }

                        //Check if var is on the identifiersList
                        if (removedToken.Code == (int)IdentifierEnum.Identifier && nextToken.Code == (int)SpecialSymbolEnum.Definition)
                        {
                            if (!semanticAnalyzer.SearchWithoutLevel(semanticAnalyzer.CreateIdentifier(removedToken.Value, "VAR", "", currentLevel)))
                            {
                                throw new SemanticException(GetLineColumnText(removedToken.StartChar) + "Variavel atribuida mas não declarada!", removedToken.StartChar.Line);

                            }

                        };
                        yield return new SyntacticalAnalysisProcessing
                        {
                            RemovedToken = removedToken,
                            ExpansionStack = expansionStack,
                            LineNumber = currentToken.StartChar.Line
                        };
                    }
                    else
                    {
                        // Throw a error
                        throw new SyntacticalException(GetLineColumnText(currentToken.StartChar) + ": Sintaxe inválida. O token esperado era " + x + " (" + x.GetValue<int>() + "), porém o valor encontrado foi " + a + " (" + a.GetValue<int>() + ")", currentToken.StartChar.Line);
                    }
                }
            }
        }

        private DerivedItem CreateDerivedItem(Enum enumeration)
        {
            return new DerivedItem
            {
                Enumeration = enumeration,
                Code = enumeration.GetValue<int>(),
                Value = enumeration.ToString()
            };
        }

        private Stack<Token> CreateTokensStack(IList<Token> tokens)
        {
            Stack<Token> tokensStack = new Stack<Token>();

            foreach (Token token in tokens.Reverse())
            {
                tokensStack.Push(token);
            }

            return tokensStack;
        }

        private string GetLineColumnText(CharWrapper charWrapper)
        {
            return "(Linha: " + charWrapper.Line + ", Coluna: " + charWrapper.Position + ")";
        }

        private void SetLevel(Token token)
        {
            switch (token.Value)
            {
                case "PROGRAM":
                    currentLevel = 0;
                    break;
                case "PROCEDURE":
                    currentLevel = 1;
                    break;
                case "END":
                    currentLevel = 0;
                    break;
                default:
                    break;
            }
        }

    }
}
