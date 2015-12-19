using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace SuperBug.Politrange.Crawler.Parsers
{
    // Константин - https://github.com/zharinovkv
    public class SitemapParser: IParser
    {
        public IEnumerable<string> GetUrls(string content)
        {
            IList<string> urls = new List<string>();

            try
            {
                XmlDocument xml = new XmlDocument();

                xml.LoadXml(content);

                XmlNamespaceManager manager = new XmlNamespaceManager(xml.NameTable);

                manager.AddNamespace("s", "http://www.sitemaps.org/schemas/sitemap/0.9");
                XmlNodeList xnList = GetNodes(xml, manager, "/s:sitemapindex/s:sitemap");

                if (xnList.Count > 0)
                {
                    foreach (XmlNode node in xnList)
                    {
                        var url = node["loc"].InnerText;
                        urls.Add(url);
                    }
                }

                xnList = GetNodes(xml, manager, "/s:urlset/s:url");

                if (xnList.Count > 0)
                {
                    foreach (XmlNode node in xnList)
                    {
                        var url = node["loc"].InnerText;
                        urls.Add(url);
                    }
                }
                //                urls = (from XmlNode node in xnList select node["loc"].InnerText).ToList();

            }
            catch (Exception)
            {
                // ignored
            }

            urls = urls.Distinct().ToList();

            urls = RemoveExtGzipUrls(urls).ToList();

            return urls;
        }

        private IEnumerable<string> RemoveExtGzipUrls(IEnumerable<string> urls)
        {
            var removeExt = ".gz".ToCharArray();

            return urls.Select(x => x.TrimEnd(removeExt));
        }

        private XmlNodeList GetNodes(XmlDocument xml, XmlNamespaceManager manager, string tags)
        {
            return xml.SelectNodes(tags, manager);
        }
    }
}
