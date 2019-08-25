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
            if (!File.Exists(path))
            {
               
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (var line in textToSwrite)
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            else
            {
    
            }
        }

        public string[] ReadFile(String pathToRead)
        {
            string[] lines = File.ReadAllLines(pathToRead);

            return lines;
        }
    }
}
