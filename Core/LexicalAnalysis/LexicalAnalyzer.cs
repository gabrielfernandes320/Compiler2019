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

        public List<Token> ExtractTokens()
        {
            List<Token> tokenList = new List<Token>();

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

            OperatorsDictionary od = new OperatorsDictionary();
            OperatorsEnum oe;

            while (revLetterStk.Count() != 0)
            {
                char actualChar = GetNextChar(revLetterStk);


                //Numbers Finite automaton
                if (char.IsDigit(actualChar))
                {
                    Token token = new Token();
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

                    token.Code = (int)ReservedWordsEnum.Inteiro;
                    token.Value = strToConcate;
                    tokenList.Add(token);
                    strToConcate = "";
                }
                //Numbers Finite automaton

                //Operators Finite automaton
                if (od.Operators.ContainsKey(actualChar.ToString()))
                {
                    Token token = new Token();
                    strToConcate = actualChar.ToString();
                    od.Operators.TryGetValue(actualChar.ToString(), out oe);
                    token.Code = (int)oe;
                    token.Value = strToConcate;
                    tokenList.Add(token);
                    strToConcate = "";
                }

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
