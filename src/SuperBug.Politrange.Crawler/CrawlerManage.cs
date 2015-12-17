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

        private IEnumerable<Site> sites;

        public CrawlerManage(IStorageService storageService, ILogger logger)
        {
            this.storageService = storageService;
            this.logger = logger;

            PopulateSites();
        }

        public void InitializationCrawler()
        {
            logger.Info("Crawler initialize");

            var container = AutofacContainer.Get();

            foreach (Site site in sites)
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    scope.Resolve<ICrawlerPersonRankService>();
                    scope.Resolve<IDownloadService>();
                    scope.Resolve<IPersonPageRankRepository>();
                    scope.Resolve<IStorageService>();
                    scope.Resolve<IUrlService>();
                    var processing = scope.Resolve<CrawlerProcessing>();

                    processing.InitializeProcession(site);
                }
            }
        }

        private void PopulateSites()
        {
            sites = storageService.GetSites() ?? new List<Site>();
        }
    }
}