using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SuperBug.Politrange.Crawler.Parsers
{
    // Константин - https://github.com/zharinovkv
    public class RobotsTxtParser: IParser
    {
        public IEnumerable<string> GetUrls(string content)
        {
            List<string> urls = new List<string>();
            string linkPattern = @"((www\.|(http|https|ftp|news|file)+\:\/\/)[_.a-z0-9-]+\.[a-z0-9\/_:@=.+?,##%&~-]*)";

            try
            {
                var match = Regex.Match(content, linkPattern,
                    RegexOptions.IgnoreCase | RegexOptions.Compiled,
                    TimeSpan.FromSeconds(1));
                while (match.Success)
                {
                    urls.Add(match.Groups[1].ToString());
                    match = match.NextMatch();
                }
            }
            catch (RegexMatchTimeoutException)
            {
                Console.WriteLine("Ничего не найдено.");
            }

            return urls.Distinct();
        }
    }
}
