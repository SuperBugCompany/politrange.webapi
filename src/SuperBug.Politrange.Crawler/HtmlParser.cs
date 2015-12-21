using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace SuperBug.Politrange.Crawler
{
    public class HtmlParser
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

            return urls; ;
        }
    }
}
