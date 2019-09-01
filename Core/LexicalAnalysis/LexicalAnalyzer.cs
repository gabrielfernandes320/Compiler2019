using Core.Dictionary;
using Core.Enum;
using System.Collections.Generic;
using System.Linq;

namespace Core.LexicalAnalysis
{
    public class LexicalAnalyzer
    {
        private string textToAnalyze;

        public LexicalAnalyzer(string textToAnalyze)
        {
            this.textToAnalyze = textToAnalyze;
        }

        public IList<Token> ExtractTokens()
        {
            IList<Token> tokenList = new List<Token>();

            string strToConcate = "";

            Stack<char> letterStk = new Stack<char>();
            Stack<char> revLetterStk = new Stack<char>();

            foreach (char ch in textToAnalyze)
            {
                letterStk.Push(ch);
            }

            while (letterStk.Count != 0)
            {
                revLetterStk.Push(letterStk.Pop());
            }
            // Int checking OK

            OperatorsDictionary operatorsDictionaty = new OperatorsDictionary();

            while (revLetterStk.Count() != 0)
            {
                char actualChar = GetNextChar(revLetterStk);

                ///////// Numbers Finite automaton
                if (char.IsDigit(actualChar))
                {
                    strToConcate = actualChar.ToString();
                    while (char.IsDigit(actualChar))
                    {
                        actualChar = GetNextChar(revLetterStk);
                        if (char.IsDigit(actualChar))
                        {
                            strToConcate = string.Concat(strToConcate, actualChar.ToString());
                        }
                        else
                        {
                            actualChar = GetNextChar(revLetterStk);
                        }
                    }

                    Token token = new Token
                    {
                        Type = NumberEnum.Integer,
                        Value = strToConcate
                    };

                    tokenList.Add(token);
                }
                ////////// Numbers Finite automaton

                ////////// Operators Finite automation
                if (operatorsDictionaty.operators.ContainsKey(actualChar.ToString()))
                {
                    strToConcate = actualChar.ToString();

                    OperatorEnum operatorEnum;
                    operatorsDictionaty.operators.TryGetValue(actualChar.ToString(), out operatorEnum);

                    Token token = new Token
                    {
                        Type = operatorEnum,
                        Value = strToConcate
                    };
                    
                    tokenList.Add(token);
                }
                ////////// Operators Finite automation
            }
            return tokenList;

        }

        private char GetNextChar(Stack<char> stk)
        {
            if (stk.Count() == 0)
            {
                return '\0';
            }

            return stk.Pop();
        }
    }
}
