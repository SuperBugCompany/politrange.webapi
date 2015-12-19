using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Extras.NLog;
using SuperBug.Politrange.Crawler.Services;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Crawler
{
    public class CrawlerManage
    {
        private readonly ILogger logger;
        private readonly IStorageService storageService;

        public CrawlerManage(IStorageService storageService, ILogger logger)
        {
            this.storageService = storageService;
            this.logger = logger;
        }

        public void InitializeCrawler()
        {
            logger.Info("Crawler initialize");

            var container = AutofacContainer.GetContainer();

            IEnumerable<Page> pages = storageService.GetManyPages(x => x.LastScanDate == null);

            Queue<Page> newPages = new Queue<Page>(pages);

            while (newPages.Any())
            {
                var page = newPages.Dequeue();

                using (var scope = container.BeginLifetimeScope())
                {
                    var processing = scope.ResolveOptional<CrawlerProcessing>();

                    logger.Info("Inittialize procesion new page: " + page.Uri);

                    processing.InitializeProcession(page);

                    logger.Info("Completed procession new page: " + page.Uri);
                }

                if (!newPages.Any())
                {
                    pages = storageService.GetManyPages(x => x.LastScanDate == null);
                    newPages = new Queue<Page>(pages);
                }
            }

            pages = storageService.GetManyPages(x => x.LastScanDate < DateTime.Today.AddDays(-1));

            Queue<Page> oldPages = new Queue<Page>(pages);

            while (oldPages.Any())
            {
                var page = newPages.Dequeue();

                using (var scope = container.BeginLifetimeScope())
                {
                    var processing = scope.ResolveOptional<CrawlerProcessing>();

                    logger.Info("Inittialize procesion old page: " + page.Uri);

                    processing.InitializeProcession(page);

                    logger.Info("Completed procession old page: " + page.Uri);
                }

                if (!oldPages.Any())
                {
                    pages = storageService.GetManyPages(x => x.LastScanDate == null);
                    oldPages = new Queue<Page>(pages);
                }
            }
        }
    }
}