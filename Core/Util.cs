using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Dictionary;
using Core.Enum;


namespace CompilerCore.Utils
{
    public class Util
    {
        List<String> reservedWords = new List<string>();


        public void WriteFile(String[] textToSwrite)
        {

            string path = @"C:\temp\test.txt";

            File.Delete(path);
            using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (var line in textToSwrite)
                    {
                        sw.WriteLine(line);
                    }
                }
           
        }

        public string ReadFile(String pathToRead)
        {
            string letters = File.ReadAllText(pathToRead);

            return letters;
        }

        public List<Token> LexicalAnalysis(string lettersToAnalyze)
        {
            List<Token> tokenList = new List<Token>();
            
            String strToConcate = "";

            Stack<char> letterStk = new Stack<char>();
            Stack<char> revLetterStk = new Stack<char>();

            foreach (char ch in lettersToAnalyze)
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
                if (Char.IsDigit(actualChar))
                {
                    Token token = new Token();
                    strToConcate = actualChar.ToString();
                            while (Char.IsDigit(actualChar))
                            {
                                actualChar = GetNextChar(revLetterStk);
                                if (Char.IsDigit(actualChar))
                                {
                                    strToConcate = String.Concat(strToConcate, actualChar.ToString());
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
           if(stk.Count() == 0)
            {
                return '\0';
            }
            return stk.Pop();
        }

    }    

}

