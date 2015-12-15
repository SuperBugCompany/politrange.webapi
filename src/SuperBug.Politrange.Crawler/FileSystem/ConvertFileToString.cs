using System.IO;

namespace SuperBug.Politrange.Crawler.FileSystem
{
    public class ConvertFileToString
    {
        public string GetContent(byte[] bytes)
        {
            string text;

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                StreamReader reader = new StreamReader(memoryStream);

                text = reader.ReadToEnd();
            }

            return text;
        }
    }
}