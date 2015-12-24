using System.Collections.Generic;
using HtmlAgilityPack;

namespace SuperBug.Politrange.Crawler.Parsers
{
    public class HtmlParser: IParser
    {
        public IEnumerable<string> GetUrls(string content)
        {
            ICollection<string> urls = new List<string>();

            if (!string.IsNullOrWhiteSpace(content))
            {
                HtmlDocument doc = new HtmlDocument();

                doc.LoadHtml(content);

                var nodes = doc.DocumentNode.SelectNodes("//a[@href]");

                foreach (HtmlNode node in nodes)
                {
                    urls.Add(node.Attributes["href"].Value);
                }
            }

            return urls;
        }
    }
}