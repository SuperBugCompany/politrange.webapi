using System.IO;
using RestSharp;

namespace SuperBug.Politrange.Crawler.Downloaders
{
    public interface IDownloader
    {
        string Download(string url);
        byte[] DownloadFile(string url);
    }

    public class Downloader: IDownloader
    {
        public string Download(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest();
            var response = client.Execute(request);

            var content = response.Content;

            return content;
        }

        public byte[] DownloadFile(string url)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                var client = new RestClient(url);
                var request = new RestRequest();
                request.ResponseWriter = responseStream => responseStream.CopyTo(memoryStream);
                client.DownloadData(request);

                return memoryStream.ToArray();
            }
        }
    }
}