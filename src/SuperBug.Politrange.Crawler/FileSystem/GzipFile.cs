using System.IO;
using System.IO.Compression;

namespace SuperBug.Politrange.Crawler.FileSystem
{
    public class GzipFile
    {
        public byte[] Decompress(byte[] gzip)
        {
            byte[] bytes;

            using (GZipStream zipStream = new GZipStream(new MemoryStream(gzip), CompressionMode.Decompress))
            {
                int size = 4096;

                byte[] buffer = new byte[size];

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    int count = 0;
                    do
                    {
                        count = zipStream.Read(buffer, 0, size);
                        if (count > 0)
                        {
                            memoryStream.Write(buffer, 0, count);
                        }
                    } while (count > 0);

                    bytes = memoryStream.ToArray();
                }
            }

            return bytes;
        }
    }
}