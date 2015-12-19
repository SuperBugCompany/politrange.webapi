using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Extras.NLog;
using SuperBug.Politrange.Crawler.Services;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Crawler
{
    public class CrawlerProcessing
    {
        private readonly ICrawlerPersonRankService crawlerPersonRankService;
        private readonly IDownloadService downloadService;
        private readonly ILogger logger;
        private readonly IStorageService storageService;
        private readonly IUrlService urlService;

        private Page currentPage;

        public CrawlerProcessing(
            IStorageService storageService,
            IDownloadService downloadService,
            IUrlService urlService,
            ICrawlerPersonRankService crawlerPersonRankService,
            ILogger logger)
        {
            this.storageService = storageService;
            this.downloadService = downloadService;
            this.urlService = urlService;
            this.crawlerPersonRankService = crawlerPersonRankService;
            this.logger = logger;
        }

        public void InitializeProcession(Page page)
        {
            currentPage = page;

            logger.Info("Current page: " + currentPage.Uri);

            logger.Info("Download: " + page.Uri);

            var downloadPage = Download(page);

            logger.Info("Download completed" + page.Uri);

            logger.Info("Update current page");

            UpdateLastScanDatePage(downloadPage.Key);

            logger.Info("Parse urls by " + page.Uri);

            var urls = FetchingUrlsByPage(downloadPage);

            logger.Info("Founded urls: " + urls.Count());

            logger.Info("Creating pages");

            var newPages = CreatePages(currentPage.Site, urls);

            logger.Info("Save new pages in Database");

            int countSaved = SavePagesStorage(newPages);

            logger.Info("Saved pages: " + countSaved);

            logger.Info("Detecting keywords");

            var personPageRanks = DetectingKeywords(downloadPage);

            logger.Info("Founded rank persons: " + personPageRanks.Count());

            logger.Info("Save new rank persons in Database");

            countSaved = SavePersonRageRankStorage(personPageRanks);

            logger.Info("Saved rank persons: " + countSaved);
        }

        private void UpdateLastScanDatePage(Page page)
        {
            storageService.UpdatePage(page);
        }

        private KeyValuePair<Page, string> Download(Page page)
        {
            var content = downloadService.Download(page.Uri);

            page.LastScanDate = DateTime.Now;

            var downloadPage = new KeyValuePair<Page, string>(page, content);

            return downloadPage;
        }

        private IEnumerable<string> FetchingUrlsByPage(KeyValuePair<Page, string> page)
        {
            return urlService.GetUrls(page);
        }

        private IEnumerable<Page> CreatePages(Site site, IEnumerable<string> urls)
        {
            ICollection<Page> pages = new List<Page>();

            foreach (string url in urls)
            {
                var page = new Page()
                {
                    Uri = url,
                    Site = site,
                    FoundDate = DateTime.Now
                };

                pages.Add(page);
            }

            return pages;
        }

        private int SavePagesStorage(IEnumerable<Page> pages)
        {
            return storageService.InsertPages(pages);
        }

        private int SavePersonRageRankStorage(IEnumerable<PersonPageRank> ranks)
        {
            return storageService.InsertRanks(ranks);
        }

        private IEnumerable<PersonPageRank> DetectingKeywords(KeyValuePair<Page, string> downloadPage)
        {
            List<PersonPageRank> personPageRanks = new List<PersonPageRank>();

            var ranks = crawlerPersonRankService.GetPersonPageRanks(downloadPage);

            personPageRanks.AddRange(ranks);

            return personPageRanks;
        }
    }
}