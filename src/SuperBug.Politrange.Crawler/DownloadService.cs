using System.Collections.Generic;
using System.IO;
using SuperBug.Politrange.Crawler.Downloaders;
using SuperBug.Politrange.Crawler.FileSystem;

namespace SuperBug.Politrange.Crawler
{
    public interface IDownloadService
    {
        string Download(string url);
    }

    public class DownloadService: IDownloadService
    {
        private readonly IDownloader downloader;

        public DownloadService(IDownloader downloader)
        {
            this.downloader = downloader;
        }

        public string Download(string url)
        {
            var content = string.Empty;

            var ext = Path.GetExtension(url);

            switch (ext)
            {
                case ".gz":
                    content = DownloadGzip(url);
                    break;
                default:
                    content = DownloadContent(url);
                    break;
            }

            return content;
        }

        public string DownloadContent(string url)
        {
            return downloader.Download(url);
        }

        public string DownloadGzip(string url)
        {
            var gzip = downloader.DownloadFile(url);

            GzipFile gzipFile = new GzipFile();

            var unpacked = gzipFile.Decompress(gzip);

            ConvertFileToString convertFileToString = new ConvertFileToString();

            var content = convertFileToString.GetContent(unpacked);

            return content;
        }
    }
}