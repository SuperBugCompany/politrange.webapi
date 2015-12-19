using System;
using Autofac;

namespace SuperBug.Politrange.Crawler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WindowWidth = 120;
            Console.BufferWidth = 120;

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