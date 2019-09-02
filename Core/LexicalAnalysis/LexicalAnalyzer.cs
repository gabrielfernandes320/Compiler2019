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

        public LexicalAnalyzer(string textToAnalyze)
        {
            this.textToAnalyze = textToAnalyze;
        }

        public Stack<Token> ExtractTokens()
        {
            Stack<Token> tokenStack = new Stack<Token>();

            Stack<char> charsToAnalyze = new Stack<char>(textToAnalyze.ToCharArray().Reverse());

            this.currentChar = GetNextChar(charsToAnalyze);

            while (charsToAnalyze.Count != 0)
            {
                Queue procedureQueue = new Queue();

                /*
                 * Atenção!
                 * Quando um procedimento encontrar um token, é responsabilidade dele avançar o caracter a ser analizado
                 */

                // Procedure Digits
                procedureQueue.Enqueue(ExtractDigitsProcedure(charsToAnalyze));

                // Procedure Operators (Signals: +, >, >=...)
                procedureQueue.Enqueue(ExtractSignalOperatorsProcedure(charsToAnalyze));

                // Procedure Alphanumeric (Extract identifier, reserved words and alphanumeric operators)
                procedureQueue.Enqueue(ExtractAlphanumericProcedure(charsToAnalyze));

                // Procedure Literals
                procedureQueue.Enqueue(ExtractLiteralProcedure(charsToAnalyze));

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
                    // Validate if current char is invalid
                    if (!char.IsWhiteSpace(this.currentChar) && !this.currentChar.Equals('\r') && !this.currentChar.Equals('\n'))
                    {
                        // TODO: Ativar essa validação quando todas as procedures estiverem terminadas
                        // throw new LexicalException("O caracter " + this.currentChar + " não é permitido");
                    }

                    this.currentChar = GetNextChar(charsToAnalyze);
                }
            }

            return tokenStack;
        }

        private Token ExtractDigitsProcedure(Stack<char> charsToAnalyze)
        {
            string strToConcate = "";
            char nextChar = PreviewNextChar(charsToAnalyze);

            // Negative number signal
            if (this.currentChar.Equals('-') && char.IsDigit(nextChar))
            {
                strToConcate = this.currentChar.ToString();

                this.currentChar = GetNextChar(charsToAnalyze);
            }

            if (char.IsDigit(this.currentChar))
            {
                while (char.IsDigit(this.currentChar))
                {
                    strToConcate = string.Concat(strToConcate, this.currentChar.ToString());

                    this.currentChar = GetNextChar(charsToAnalyze);
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
            if (!char.IsLetterOrDigit(this.currentChar) && !char.IsWhiteSpace(this.currentChar))
            {
                char nextChar = PreviewNextChar(charsToAnalyze);
                Token extractedOperator;

                // Ignore letters, digits and white space
                if (!char.IsLetterOrDigit(nextChar) && !char.IsWhiteSpace(nextChar))
                {
                    // Check for operators with two chars
                    string composedOperator = this.currentChar.ToString() + nextChar.ToString();
                    extractedOperator = GetOperatorToken(composedOperator);

                    if (extractedOperator != null)
                    {
                        // Foward two chars since was analyze the current and the next positions
                        this.currentChar = GetNextChar(charsToAnalyze);
                        this.currentChar = GetNextChar(charsToAnalyze);

                        return extractedOperator;
                    }
                }

                // Check for operators with one char
                extractedOperator = GetOperatorToken(this.currentChar.ToString());

                if (extractedOperator != null)
                {
                    this.currentChar = GetNextChar(charsToAnalyze);

                    return extractedOperator;
                }
            }

            return null;
        }

        private Token ExtractAlphanumericProcedure(Stack<char> charsToAnalyze)
        {
            if (char.IsLetter(this.currentChar))
            {
                string strToConcate = "";

                while (char.IsLetterOrDigit(this.currentChar))
                {
                    strToConcate = string.Concat(strToConcate, this.currentChar.ToString());

                    this.currentChar = GetNextChar(charsToAnalyze);
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
            if (this.currentChar.Equals('\''))
            {
                string strToConcate = "'";

                this.currentChar = GetNextChar(charsToAnalyze);

                while (!this.currentChar.Equals('\''))
                {
                    strToConcate = string.Concat(strToConcate, this.currentChar.ToString());

                    this.currentChar = GetNextChar(charsToAnalyze);
                }

                strToConcate = string.Concat(strToConcate, "'");

                this.currentChar = GetNextChar(charsToAnalyze);

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
            bool exists = System.Enum.IsDefined(typeof(ReservedWordEnum), expectedOperator);

            if (exists)
            {
                return new Token
                {
                    Type = (ReservedWordEnum)System.Enum.Parse(typeof(ReservedWordEnum), expectedOperator, true),
                    Value = expectedOperator
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
