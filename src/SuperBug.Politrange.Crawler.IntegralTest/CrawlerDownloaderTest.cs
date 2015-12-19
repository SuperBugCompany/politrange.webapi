using System.IO;
using SuperBug.Politrange.Crawler.Downloaders;
using SuperBug.Politrange.Crawler.FileSystem;
using Xunit;
using Xunit.Abstractions;

namespace SuperBug.Politrange.Crawler.IntegralTest
{
    //Todo: non-unit-test
    public class CrawlerDownloaderTest
    {
        private readonly ITestOutputHelper output;

        public CrawlerDownloaderTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void ShouldBeReturnContentByText()
        {
            //arrange
            IDownloader downloader = new Downloader();

            var url = "http://lenta.ru/robots.txt";

            //act
            var result = downloader.Download(url);

            //assert
            Assert.True(result.Length > 0);

            output.WriteLine(result);
        }

        [Fact]
        public void ShouldBeReturnContentByXml()
        {
            //arrange
            IDownloader downloader = new Downloader();

            var url = "http://cdn.lenta.ru/sitemaps/sitemap.xml";

            //act
            var result = downloader.Download(url);

            //assert
            Assert.True(result.Length > 0);

            output.WriteLine(result);
        }

        [Fact]
        public void ShouldBeReturnContentByHtml()
        {
            //arrange
            IDownloader downloader = new Downloader();

            var url = "http://lenta.ru/news/2007/08/03/vodka/";

            //act
            var result = downloader.Download(url);

            //assert
            Assert.True(result.Length > 0);

            output.WriteLine(result);
        }

        [Fact]
        public void ShouldBeReturnContentByGzip()
        {
            //arrange
            IDownloader downloader = new Downloader();
            GzipFile gzipFile = new GzipFile();
            ConvertFileToString convertFileToString = new ConvertFileToString();

            var url = "http://lenta.ru/sitemaps/sitemap-news.xml.gz";

            //act
            var gzip = downloader.DownloadFile(url);

            var unpacked = gzipFile.Decompress(gzip);

            var result = convertFileToString.GetContent(unpacked);

            //assert
            Assert.True(result.Length > 0);

            output.WriteLine(result);
        }

        private Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}