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
            List<Token> analyzedText = new List<Token>();

            foreach (var line in textToAnalyze )
            {
                foreach (char letter in line)
                {
                    if(CheckIfIsSpecialWord(letter))
                    {

                    }
                }
            }

            return analyzedText;
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
