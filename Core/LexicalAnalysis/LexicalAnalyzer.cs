﻿using Core.Dictionary;
using Core.Enum;
using Core.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Core.LexicalAnalysis
{
    public class LexicalAnalyzer
    {
        // Text to be analyzed (Each item corresponds to line)
        private string[] textToAnalyze;

        // Control the position in the analyze
        CharWrapper currentItem;

        // Constants
        private const char APOSTROPHE = '\'';
        private const char PARENTHESES_INI = '(';
        private const char PARENTHESES_END = ')';
        private const char ASTERISK = '*';
        private const char MINUS = '-';

        public LexicalAnalyzer(string[] textToAnalyze)
        {
            this.textToAnalyze = textToAnalyze;
        }

        public Stack<Token> ExtractTokens()
        {
            Stack<Token> tokenStack = new Stack<Token>();

            // Create a stack of CharWrapper to analyze
            Stack<CharWrapper> items = CreateItemsStack(textToAnalyze);

            currentItem = GetNextItem(items);

            while (items.Count != 0)
            {
                Queue procedureQueue = new Queue();

                /*
                 * Atenção!
                 * Quando um procedimento encontrar um token, é responsabilidade dele avançar para o próximo item a ser analizado
                 */

                // Procedure Comments
                ClearCommentProcedure(items);

                // Procedure Literals
                procedureQueue.Enqueue(ExtractLiteralProcedure(items));

                // Procedure Digits
                procedureQueue.Enqueue(ExtractDigitsProcedure(items));

                // Procedure Operators (Signals: +, >, >=...)
                procedureQueue.Enqueue(ExtractSignalOperatorsProcedure(items));

                // Procedure Alphanumeric (Extract identifier, reserved words and alphanumeric operators)
                procedureQueue.Enqueue(ExtractAlphanumericProcedure(items));

                // Procedure Special Symbols
                procedureQueue.Enqueue(ExtractSpecialSymbolProcedure(items));

                // Iterate over each item in the queue to create the stack
                bool hasAnyValidToken = false;
                foreach (Token procedure in procedureQueue)
                {
                    if (procedure != null)
                    {
                        hasAnyValidToken = true;

                        tokenStack.Push(procedure);
                    }
                }

                // If all procedure do not returns a valid toke
                if (!hasAnyValidToken)
                {
                    // TODO: Talvez implementar aqui validator para caracteres inválidos

                    currentItem = GetNextItem(items);
                }
            }

            return tokenStack;
        }

        private void ClearCommentProcedure(Stack<CharWrapper> items)
        {
            CharWrapper nextItem = PreviewNextItem(items);

            if (currentItem.Char.Equals(PARENTHESES_INI) && nextItem.Char.Equals(ASTERISK))
            {
                currentItem = GetNextItem(items);

                while (!(currentItem.Char.Equals(ASTERISK) && PreviewNextItem(items).Char.Equals(PARENTHESES_END)))
                {
                    currentItem = GetNextItem(items);
                }

                currentItem = GetNextItem(items);
                currentItem = GetNextItem(items);
            }
        }

        private Token ExtractDigitsProcedure(Stack<CharWrapper> items)
        {
            string strToConcate = "";
            CharWrapper startItem = null;
            CharWrapper nextItem = PreviewNextItem(items);

            // Negative number signal
            if (currentItem.Char.Equals(MINUS) && char.IsDigit(nextItem.Char))
            {
                strToConcate = currentItem.ToString();
                startItem = currentItem;

                currentItem = GetNextItem(items);
            }

            if (char.IsDigit(currentItem.Char))
            {
                while (char.IsDigit(currentItem.Char))
                {
                    strToConcate = string.Concat(strToConcate, currentItem.ToString());
                    startItem = startItem ?? currentItem;

                    nextItem = PreviewNextItem(items);

                    // Validade if number can be beginning of an identificator
                    if (char.IsLetter(nextItem.Char))
                    {
                        throw new LexicalException(GetLineColumnText(startItem) + ": Identificadores não podem iniciar com números: " + strToConcate + nextItem + "...");
                    }

                    currentItem = GetNextItem(items);
                    nextItem = PreviewNextItem(items);

                    // Validade if number contains decimal separator
                    if (char.IsDigit(nextItem.Char) && currentItem.Char.Equals('.'))
                    {
                        throw new LexicalException(GetLineColumnText(startItem) + ": Números não podem conter ponto flutuante: " + strToConcate + currentItem + nextItem + "...");
                    }
                }

                // Validate if extracted number is the range –32767, 32767
                int parsedNumber = int.Parse(strToConcate);
                if (parsedNumber.CompareTo(-32767) == -1 || parsedNumber.CompareTo(32767) == 1)
                {
                    throw new LexicalException(GetLineColumnText(startItem) + ": O número " + strToConcate + " está fora do intervalo permitido -32767 a 32767");
                }

                return new Token
                {
                    Type = NumberEnum.Integer,
                    Value = strToConcate,
                    StartChar = startItem
                };
            }

            return null;
        }

        private Token ExtractSignalOperatorsProcedure(Stack<CharWrapper> items)
        {
            // Ignore letters, digits and white space
            if (!char.IsLetterOrDigit(currentItem.Char) && !char.IsWhiteSpace(currentItem.Char))
            {
                CharWrapper nextItem = PreviewNextItem(items);
                Token extractedOperator;

                // Ignore letters, digits and white space
                if (!char.IsLetterOrDigit(nextItem.Char) && !char.IsWhiteSpace(nextItem.Char))
                {
                    // Check for operators with two chars
                    string composedOperator = currentItem.ToString() + nextItem.ToString();
                    extractedOperator = GetOperatorToken(composedOperator);

                    if (extractedOperator != null)
                    {
                        extractedOperator.StartChar = currentItem;

                        // Foward two chars since was analyze the current and the next positions
                        currentItem = GetNextItem(items);
                        currentItem = GetNextItem(items);

                        return extractedOperator;
                    }
                }

                // Check for operators with one char
                extractedOperator = GetOperatorToken(currentItem.ToString());

                if (extractedOperator != null)
                {
                    extractedOperator.StartChar = currentItem;

                    currentItem = GetNextItem(items);

                    return extractedOperator;
                }
            }

            return null;
        }

        private Token ExtractAlphanumericProcedure(Stack<CharWrapper> items)
        {
            if (char.IsLetter(currentItem.Char))
            {
                string strToConcate = "";
                CharWrapper startItem = currentItem;

                while (char.IsLetterOrDigit(currentItem.Char))
                {
                    strToConcate = string.Concat(strToConcate, currentItem.ToString());

                    currentItem = GetNextItem(items);
                }

                // Verify if extracted string contains in...
                // Operators
                Token extractedOperator = GetOperatorToken(strToConcate);
                if (extractedOperator != null)
                {
                    extractedOperator.StartChar = startItem;

                    return extractedOperator;
                }

                // Reserved Words
                Token extractedReservedWord = GetReservedWordToken(strToConcate);
                if (extractedReservedWord != null)
                {
                    extractedReservedWord.StartChar = startItem;

                    return extractedReservedWord;
                }


                // Otherwise is Identifier
                if (strToConcate.Count() > 30)
                {
                    throw new LexicalException(GetLineColumnText(startItem) + ": O identificador " + strToConcate + " possui mais que os 30 caracteres limite");
                }

                return new Token
                {
                    Type = IdentifierEnum.Identifier,
                    Value = strToConcate,
                    StartChar = startItem
            };
            }

            return null;
        }

        private Token ExtractLiteralProcedure(Stack<CharWrapper> items)
        {
            // On found an apostrophe
            if (currentItem.Char.Equals(APOSTROPHE))
            {
                string strToConcate = char.ToString(APOSTROPHE);
                CharWrapper startItem = currentItem;

                currentItem = GetNextItem(items);

                // Continues until found final apostrophe
                while (!currentItem.Char.Equals(APOSTROPHE))
                {
                    // If a newline was found, must throw a exception
                    if (currentItem.Line != startItem.Line)
                    {
                        throw new LexicalException(GetLineColumnText(startItem) + ": Não é permitido quebra de linha em literais: " + strToConcate);
                    }

                    strToConcate = string.Concat(strToConcate, currentItem.ToString());

                    currentItem = GetNextItem(items);
                }

                strToConcate = string.Concat(strToConcate, char.ToString(APOSTROPHE));

                currentItem = GetNextItem(items);

                if (strToConcate.Count() > 257) // 257 -> 255 + apostrophe
                {
                    throw new LexicalException(GetLineColumnText(startItem) + ": O literal " + strToConcate + " possui mais que os 255 caracteres limite");
                }

                return new Token
                {
                    Type = LiteralEnum.Literal,
                    Value = strToConcate,
                    StartChar = startItem
                };
            }

            return null;
        }

        private Token ExtractSpecialSymbolProcedure(Stack<CharWrapper> items)
        {
            // To avoid conflict with open comment symbol "(*" and "(" symbol, call method to clear comment before continue
            ClearCommentProcedure(items);

            // Ignore white space
            if (!char.IsWhiteSpace(currentItem.Char))
            {
                CharWrapper nextItem = PreviewNextItem(items);

                Token extractedSymbol;

                // Ignore white space
                if (!char.IsWhiteSpace(nextItem.Char))
                {
                    // Check for symbols with two chars
                    string composedSymbol = currentItem.ToString() + nextItem.ToString();
                    extractedSymbol = GetSpecialSymbolToken(composedSymbol);

                    if (extractedSymbol != null)
                    {
                        extractedSymbol.StartChar = currentItem;

                        // Foward two chars since was analyze the current and the next positions
                        currentItem = GetNextItem(items);
                        currentItem = GetNextItem(items);

                        return extractedSymbol;
                    }
                }

                // Check for symbols with one char
                extractedSymbol = GetSpecialSymbolToken(currentItem.ToString());

                if (extractedSymbol != null)
                {
                    extractedSymbol.StartChar = currentItem;

                    currentItem = GetNextItem(items);

                    return extractedSymbol;
                }
            }

            return null;
        }

        private Token GetOperatorToken(string expectedOperator)
        {
            OperatorsDictionary operatorsDictionaty = new OperatorsDictionary();

            if (operatorsDictionaty.operators.ContainsKey(expectedOperator.ToLower()))
            {
                OperatorEnum operatorEnum;
                operatorsDictionaty.operators.TryGetValue(expectedOperator.ToLower(), out operatorEnum);

                return new Token
                {
                    Type = operatorEnum,
                    Value = expectedOperator
                };
            }

            return null;
        }

        private Token GetReservedWordToken(string expectedOperator)
        {
            bool exists = System.Enum.TryParse<ReservedWordEnum>(expectedOperator, true, out _);

            if (exists)
            {
                return new Token
                {
                    Type = (ReservedWordEnum)System.Enum.Parse(typeof(ReservedWordEnum), expectedOperator, true),
                    Value = expectedOperator.ToUpper()
                };
            }

            return null;
        }

        private Token GetSpecialSymbolToken(string expectedSymbol)
        {
            SpecialSymbolsDictionary symbolsDictionaty = new SpecialSymbolsDictionary();

            if (symbolsDictionaty.symbols.ContainsKey(expectedSymbol.ToLower()))
            {
                // TODO: Create a validation to check if open brackets and parentheses was closed

                SpecialSymbolEnum symbolEnum;
                symbolsDictionaty.symbols.TryGetValue(expectedSymbol.ToLower(), out symbolEnum);

                return new Token
                {
                    Type = symbolEnum,
                    Value = expectedSymbol
                };
            }

            return null;
        }

        private Stack<CharWrapper> CreateItemsStack(string[] textToAnalyze)
        {
            Stack<CharWrapper> items = new Stack<CharWrapper>();

            for (int i = textToAnalyze.Length - 1; i >= 0; i--)
            {
                for (int j = textToAnalyze[i].Length - 1; j >= 0; j--)
                {
                    items.Push(new CharWrapper
                    {
                        Char = textToAnalyze[i][j],
                        Line = i + 1,
                        Position = j + 1
                    }); ;
                }
            }

            return items;
        }

        private string GetLineColumnText(CharWrapper charWrapper)
        {
            return "(Linha: " + charWrapper.Line + ", Coluna: " + charWrapper.Position + ")";
        }

        private CharWrapper GetNextItem(Stack<CharWrapper> stk)
        {
            if (stk.Count() == 0)
            {
                return new CharWrapper();
            }

            return stk.Pop();
        }

        private CharWrapper PreviewNextItem(Stack<CharWrapper> stk, int position = 0)
        {
            CharWrapper nextItem = stk.ElementAtOrDefault(position);

            return nextItem ?? new CharWrapper();
        }
    }
}
