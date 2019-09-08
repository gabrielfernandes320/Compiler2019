using System.IO;

namespace Core.Utils
{
    public class FileHandler
    {
        public void WriteFile(string[] textToSwrite, string path)
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

        public string GetText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
