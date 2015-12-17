using System.Collections.Generic;
using System.IO;
using SuperBug.Politrange.Crawler.Parsers;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Crawler
{
    public interface IUrlService
    {
        IEnumerable<string> GetAllUrls(IDictionary<Page, string> pages);
    }

    public class UrlService: IUrlService
    {
        public UrlService()
        {
        }

        public IEnumerable<string> GetAllUrls(IDictionary<Page, string> pages)
        {
            List<string> urls = new List<string>();

            foreach (KeyValuePair<Page, string> page in pages)
            {
                urls.AddRange(GetUrls(page));
            }

            return urls;
        }

        public IEnumerable<string> GetUrls(KeyValuePair<Page, string> page)
        {
            IEnumerable<string> urls = new List<string>();

            IParser parser = null;

            var ext = Path.GetExtension(page.Key.Uri);

            switch (ext)
            {
                case ".txt":
                    urls = ParsingUrls(new RobotsTxtParser(), page.Value);
                    break;
                case ".xml":
                    urls = ParsingUrls(new SitemapParser(), page.Value);
                    break;
                default:
                    break;
            }

            return urls;
        }

        private IEnumerable<string> ParsingUrls(IParser parser, string content)
        {
            IEnumerable<string> urls = new List<string>();

            if (parser != null)
            {
                urls = parser.GetUrls(content);
            }

            return urls;
        }
    }
}