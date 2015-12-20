using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
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
        private readonly Timer timer;
        private bool isProcessing;

        public CrawlerManage(IStorageService storageService, ILogger logger)
        {
            this.storageService = storageService;
            this.logger = logger;
            this.timer = new Timer()
            {
                Enabled = true,
                Interval = 600000,
                AutoReset = true,
            };
        }

        public void InitializeCrawler()
        {
            this.timer.Elapsed += TimerOnElapsed;
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            if (!isProcessing)
            {
                isProcessing = true;

                ProcessingCrawler();

                isProcessing = false;
            }
        }

        public void ProcessingCrawler()
        {
            logger.Info("Начата работа краулера");

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

            logger.Info("Работа краулера завершена");
        }
    }
}