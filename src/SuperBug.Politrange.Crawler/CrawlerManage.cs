using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Extras.NLog;
using SuperBug.Politrange.Data.Repositories;
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

        public void InitializationCrawler()
        {
            logger.Info("Crawler initialize");

            var container = AutofacConfiguration.BuildAutofacContainer();

            IEnumerable<Page> pages = storageService.GetManyPages(x => x.LastScanDate == null);

            foreach (Page page in pages)
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    var processing = scope.ResolveOptional<CrawlerProcessing>();

                    logger.Info("Inittialize procesion page: " + page.Uri);

                    processing.InitializeProcession(page);

                    logger.Info("Completed procession page: " + page.Uri);
                }
            }
        }
    }
}