using System.Collections.Generic;

namespace SuperBug.Politrange.Crawler.Parsers
{
    public interface IParser
    {
        IEnumerable<string> GetUrls(string content);
    }
}