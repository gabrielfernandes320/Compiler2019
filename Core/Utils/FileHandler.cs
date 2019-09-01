using System;
using System.IO;

namespace Core.Utils
{
    public class FileHandler
    {
        private string path = @Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/test.txt";

        public void WriteFile(string[] textToSwrite)
        {
            File.Delete(path);
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (var line in textToSwrite)
                {
                    sw.WriteLine(line);
                }
            }
        }

        public string GetText()
        {
            return File.ReadAllText(this.path);
        }
    }
}
