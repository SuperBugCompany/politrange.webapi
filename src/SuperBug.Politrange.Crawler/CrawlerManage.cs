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
                    scope.Resolve<ICrawlerPersonRankService>();
                    scope.Resolve<IDownloadService>();
                    scope.Resolve<IPersonPageRankRepository>();
                    scope.Resolve<IStorageService>();
                    scope.Resolve<IUrlService>();
                    var processing = scope.Resolve<CrawlerProcessing>();

                    processing.InitializeProcession(page);
                }
            }
        }
    }
}