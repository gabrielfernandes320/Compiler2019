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

        public string[] ReadFile(String pathToRead)
        {
            string[] lines = File.ReadAllLines(pathToRead);

            return lines;
        }

        public List<Token> LexicalAnalysis(String[] textToAnalyze)
        {
            List<Token> tokenList = new List<Token>();
            LexicalElements lxEl = new LexicalElements();

            List<Stack<char>> stkList = new List<Stack<char>>();
            foreach (var line in textToAnalyze )
            {
                Stack<char> stk = new Stack<char>();
                
                foreach (char letter in line)
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

                    if (lxEl.ReservedWords.Contains(actualChar.ToString()))
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
