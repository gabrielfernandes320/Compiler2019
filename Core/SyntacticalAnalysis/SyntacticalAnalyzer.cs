using Core.Enums;
using Core.Exceptions;
using Core.Extensions;
using Core.SyntacticalAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.SyntacticalAnalyzer
{
    public class SyntacticalAnalyzer
    {
        private readonly IDictionary<NonTerminalEnum, IDictionary<Enum, IList<Enum>>> parsingMatrix;
        private Stack<Token> tokensStack = new Stack<Token>();
        private Stack<Enum> expansionStack = new Stack<Enum>();

        public SyntacticalAnalyzer(IList<Token> tokens)
        {
            parsingMatrix = ParsingMatrixDictionary.Get();
            tokensStack = CreateTokensStack(tokens);

            expansionStack.Push(NonTerminalEnum.PROGRAMA);
        }

        public void Start()
        {
            while (expansionStack.Count > 0)
            {
                Token currentToken = tokensStack.Peek();

                Enum x = expansionStack.Peek(); // X
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
                                    expansionStack.Push(enumeration);
                                }
                            }
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
                        // Remove both from stack
                        expansionStack.Pop();
                        tokensStack.Pop();
                    } else
                    {
                        // Throw a error
                        throw new SyntacticalException(GetLineColumnText(currentToken.StartChar) + ": Sintaxe inválida. O token esperado era " + x + " (" + x.GetValue<int>() + "), porém o valor encontrado foi " + a + " (" + a.GetValue<int>() + ")", currentToken.StartChar.Line);
                    }
                }
            }
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
    }
}
