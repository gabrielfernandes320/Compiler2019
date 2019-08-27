using Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
            LexicalElements lxEl = new LexicalElements();
            String strToConcate = "";

            Stack<char> letter = new Stack<char>();

                foreach (char letter in lettersToAnalyze)
                {
                    stk.Push(letter);
                }
                stkList.Add(stk);
            }


            foreach (var stk in stkList)
            {
                while(stk.Count != 0)
                {
                    char actualChar = stk.Pop();
                    Token token = new Token();
                    if (Char.IsDigit(actualChar))
                    {
                        while (Char.IsDigit(actualChar))
                        {
                            actualChar = stk.Pop();
                            strToConcate = String.Concat(strToConcate , actualChar.ToString());
                        }

                        token.Code = 1;
                        token.Value = strToConcate;
                        tokenList.Add(token);
                        strToConcate = "";

                        
                        
                    }
                    {

                    }
                }
                

            }

            return tokenList;
        }

        private Boolean CheckIfIsSpecialWord(char Letter)
        {
            List<char> spWords = new List<char> { ':', ';', ',', '.', '(', ')', '[', ']', '\'', '=', '<', '>', '+', '-', '/', '*' };

            if (spWords.Contains(Letter))
            {
                return true;
            }
            return false;

            
        }


    }

}
