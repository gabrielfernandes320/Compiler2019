using Core.Dictionary;
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
        // Text to be analyzed
        private string textToAnalyze;

        // Control the position in the analyze
        char currentChar;

        // Constants
        private const char NEW_LINE = '\n';
        private const char APOSTROPHE = '\'';
        private const char PARENTHESES_INI = '(';
        private const char PARENTHESES_END = ')';
        private const char ASTERISK = '*';
        private const char MINUS = '-';

        public LexicalAnalyzer(string textToAnalyze)
        {
            this.textToAnalyze = textToAnalyze;
        }

        public Stack<Token> ExtractTokens()
        {
            Stack<Token> tokenStack = new Stack<Token>();

            Stack<char> charsToAnalyze = new Stack<char>(textToAnalyze.ToCharArray().Reverse());

            currentChar = GetNextChar(charsToAnalyze);

            while (charsToAnalyze.Count != 0)
            {
                Queue procedureQueue = new Queue();

                /*
                 * Atenção!
                 * Quando um procedimento encontrar um token, é responsabilidade dele avançar para o próximo caracter a ser analizado
                 */

                // Procedure Comments
                ClearCommentProcedure(charsToAnalyze);

                // Procedure Literals
                procedureQueue.Enqueue(ExtractLiteralProcedure(charsToAnalyze));

                // Procedure Digits
                procedureQueue.Enqueue(ExtractDigitsProcedure(charsToAnalyze));

                // Procedure Operators (Signals: +, >, >=...)
                procedureQueue.Enqueue(ExtractSignalOperatorsProcedure(charsToAnalyze));

                // Procedure Alphanumeric (Extract identifier, reserved words and alphanumeric operators)
                procedureQueue.Enqueue(ExtractAlphanumericProcedure(charsToAnalyze));

                // Procedure Special Symbols
                procedureQueue.Enqueue(ExtractSpecialSymbolProcedure(charsToAnalyze));

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

                    currentChar = GetNextChar(charsToAnalyze);
                }
            }

            return tokenStack;
        }

        private void ClearCommentProcedure(Stack<char> charsToAnalyze)
        {
            char nextChar = PreviewNextChar(charsToAnalyze);

            if (currentChar.Equals(PARENTHESES_INI) && nextChar.Equals(ASTERISK))
            {
                currentChar = GetNextChar(charsToAnalyze);

                while (!(currentChar.Equals(ASTERISK) && PreviewNextChar(charsToAnalyze).Equals(PARENTHESES_END)))
                {
                    currentChar = GetNextChar(charsToAnalyze);
                }

                currentChar = GetNextChar(charsToAnalyze);
                currentChar = GetNextChar(charsToAnalyze);
            }
        }

        private Token ExtractDigitsProcedure(Stack<char> charsToAnalyze)
        {
            string strToConcate = "";
            char nextChar = PreviewNextChar(charsToAnalyze);

            // Negative number signal
            if (currentChar.Equals(MINUS) && char.IsDigit(nextChar))
            {
                strToConcate = currentChar.ToString();

                currentChar = GetNextChar(charsToAnalyze);
            }

            if (char.IsDigit(currentChar))
            {
                while (char.IsDigit(currentChar))
                {
                    strToConcate = string.Concat(strToConcate, currentChar.ToString());

                    nextChar = PreviewNextChar(charsToAnalyze);

                    // Validade if number can be beginning of an identificator
                    if (char.IsLetter(nextChar))
                    {
                        throw new LexicalException("Identificadores não podem iniciar com números: " + strToConcate + nextChar + "...");
                    }

                    currentChar = GetNextChar(charsToAnalyze);
                    nextChar = PreviewNextChar(charsToAnalyze);

                    // Validade if number contains decimal separator
                    if (char.IsDigit(nextChar) && currentChar.Equals('.'))
                    {
                        throw new LexicalException("Números não podem conter ponto flutuante: " + strToConcate + currentChar + nextChar + "...");
                    }
                }

                // Validate if extracted number is the range –32767, 32767
                int parsedNumber = int.Parse(strToConcate);
                if (parsedNumber.CompareTo(-32767) == -1 || parsedNumber.CompareTo(32767) == 1)
                {
                    throw new LexicalException("O número " + strToConcate + " está fora do intervalo permitido -32767 a 32767");
                }

                return new Token
                {
                    Type = NumberEnum.Integer,
                    Value = strToConcate
                };
            }

            return null;
        }

        private Token ExtractSignalOperatorsProcedure(Stack<char> charsToAnalyze)
        {
            // Ignore letters, digits and white space
            if (!char.IsLetterOrDigit(currentChar) && !char.IsWhiteSpace(currentChar))
            {
                char nextChar = PreviewNextChar(charsToAnalyze);
                Token extractedOperator;

                // Ignore letters, digits and white space
                if (!char.IsLetterOrDigit(nextChar) && !char.IsWhiteSpace(nextChar))
                {
                    // Check for operators with two chars
                    string composedOperator = currentChar.ToString() + nextChar.ToString();
                    extractedOperator = GetOperatorToken(composedOperator);

                    if (extractedOperator != null)
                    {
                        // Foward two chars since was analyze the current and the next positions
                        currentChar = GetNextChar(charsToAnalyze);
                        currentChar = GetNextChar(charsToAnalyze);

                        return extractedOperator;
                    }
                }

                // Check for operators with one char
                extractedOperator = GetOperatorToken(currentChar.ToString());

                if (extractedOperator != null)
                {
                    currentChar = GetNextChar(charsToAnalyze);

                    return extractedOperator;
                }
            }

            return null;
        }

        private Token ExtractAlphanumericProcedure(Stack<char> charsToAnalyze)
        {
            if (char.IsLetter(currentChar))
            {
                string strToConcate = "";

                while (char.IsLetterOrDigit(currentChar))
                {
                    strToConcate = string.Concat(strToConcate, currentChar.ToString());

                    currentChar = GetNextChar(charsToAnalyze);
                }

                // Verify if extracted string contains in...
                // Operators
                Token extractedOperator = GetOperatorToken(strToConcate);
                if (extractedOperator != null)
                {
                    return extractedOperator;
                }

                // Reserved Words
                Token extractedReservedWord = GetReservedWordToken(strToConcate);
                if (extractedReservedWord != null)
                {
                    return extractedReservedWord;
                }


                // Otherwise is Identifier
                if (strToConcate.Count() > 30)
                {
                    throw new LexicalException("O identificador " + strToConcate + " possui mais que os 30 caracteres limite");
                }

                return new Token
                {
                    Type = IdentifierEnum.Identifier,
                    Value = strToConcate
                };
            }

            return null;
        }

        private Token ExtractLiteralProcedure(Stack<char> charsToAnalyze)
        {
            // On found an apostrophe
            if (currentChar.Equals(APOSTROPHE))
            {
                string strToConcate = char.ToString(APOSTROPHE);

                currentChar = GetNextChar(charsToAnalyze);

                // Continues until found final apostrophe
                while (!currentChar.Equals(APOSTROPHE))
                {
                    // If a newline was found, must throw a exception
                    if (currentChar.Equals(NEW_LINE))
                    {
                        throw new LexicalException("Não é permitido quebra de linha em literais: " + strToConcate);
                    }

                    strToConcate = string.Concat(strToConcate, currentChar.ToString());

                    currentChar = GetNextChar(charsToAnalyze);
                }

                strToConcate = string.Concat(strToConcate, char.ToString(APOSTROPHE));

                currentChar = GetNextChar(charsToAnalyze);

                if (strToConcate.Count() > 257) // 257 -> 255 + limitators
                {
                    throw new LexicalException("O literal " + strToConcate + " possui mais que os 255 caracteres limite");
                }

                return new Token
                {
                    Type = LiteralEnum.Literal,
                    Value = strToConcate
                };
            }

            return null;
        }

        private Token ExtractSpecialSymbolProcedure(Stack<char> charsToAnalyze)
        {
            // To avoid conflict with open comment symbol "(*", call method to clear comment
            ClearCommentProcedure(charsToAnalyze);

            // Ignore white space
            if (!char.IsWhiteSpace(currentChar))
            {
                char nextChar = PreviewNextChar(charsToAnalyze);

                Token extractedSymbol;

                // Ignore white space
                if (!char.IsWhiteSpace(nextChar))
                {
                    // Check for symbols with two chars
                    string composedSymbol = currentChar.ToString() + nextChar.ToString();
                    extractedSymbol = GetSpecialSymbolToken(composedSymbol);

                    if (extractedSymbol != null)
                    {
                        // Foward two chars since was analyze the current and the next positions
                        currentChar = GetNextChar(charsToAnalyze);
                        currentChar = GetNextChar(charsToAnalyze);

                        return extractedSymbol;
                    }
                }

                // Check for symbols with one char
                extractedSymbol = GetSpecialSymbolToken(currentChar.ToString());

                if (extractedSymbol != null)
                {
                    currentChar = GetNextChar(charsToAnalyze);

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

        private char GetNextChar(Stack<char> stk)
        {
            if (stk.Count() == 0)
            {
                return '\0';
            }

            return stk.Pop();
        }

        private char PreviewNextChar(Stack<char> stk, int position = 0)
        {
            return stk.ElementAtOrDefault(position);
        }
    }
}
