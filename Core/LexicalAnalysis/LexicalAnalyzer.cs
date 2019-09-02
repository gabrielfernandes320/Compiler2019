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

                // Procedure Operators
                procedureQueue.Enqueue(ExtractOperatorsProcedure(charsToAnalyze));

                // Procedure Alphanumeric (Extract literal or reserved words)
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

        private Token ExtractOperatorsProcedure(Stack<char> charsToAnalyze)
        {
            OperatorsDictionary operatorsDictionaty = new OperatorsDictionary();

            // TODO: Criar uma lógica para distinguir os operadores de um caracter, dos operadores com mais de uma caracter
            if (operatorsDictionaty.operators.ContainsKey(this.currentChar.ToString()))
            {
                string strToConcate = this.currentChar.ToString();

                OperatorEnum operatorEnum;
                operatorsDictionaty.operators.TryGetValue(this.currentChar.ToString(), out operatorEnum);

                this.currentChar = GetNextChar(charsToAnalyze);

                return  new Token
                {
                    Type = operatorEnum,
                    Value = strToConcate
                };
            }

            return null;
        }

        private Token ExtractAlphanumericProcedure(Stack<char> charsToAnalyze)
        {
            return null;
        }

        private Token ExtractLiteralProcedure(Stack<char> charsToAnalyze)
        {
            return null;
        }

        private Token ExtractSpecialSymbolProcedure(Stack<char> charsToAnalyze)
        {
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
