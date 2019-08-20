using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompilerCore.Utils
{
    public class Utils
    {
        public void WriteFile(List<String> textToSwrite)
        {
            string[] lines = { "First line", "Second line", "Third line" };

            string path = @"C:\temp\test.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    foreach (var line in textToSwrite)
                    {
                        sw.Write(line);
                    }
                }
            }
        }
    }
}
