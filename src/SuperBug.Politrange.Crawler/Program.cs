using System;
using Autofac;

namespace SuperBug.Politrange.Crawler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = AutofacContainer.Get();

            using (var scope = container.BeginLifetimeScope())
            {
                var crawlerManage = scope.Resolve<CrawlerManage>();

                crawlerManage.InitializationCrawler();
                ;
            }

            Console.ReadLine();
        }
    }
}