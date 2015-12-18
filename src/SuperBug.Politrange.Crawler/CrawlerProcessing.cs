using System;
using System.Collections.Generic;
using System.Linq;
using Autofac.Extras.NLog;
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

        private Site currentSite;

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

        public void InitializeProcession(Site site)
        {
            this.currentSite = site;

            logger.Info("FetchingPages()");
            // Селектнуть ссылку из таблицы Pages, по которой никогда не обходили
            var pages = FetchingPages(currentSite.SiteId);

            logger.Info("DownloadAll()");
            // Скачать
            var downloadPages = DownloadAll(pages);

            logger.Info("Update DB");
            // Обновить запись в бд
            storageService.UpdatePages(pages);

            logger.Info("FetchingUrls()");
            // Вызвать UrlFinder - найти ссылки на странице, по которым нужно будет еще проходиться
            var urls = FetchingUrls(downloadPages);

            logger.Info("BuildPages()");
            var newPages = BuildPages(currentSite, urls);

            logger.Info("AddPagesInStorage()");
            AddPagesInStorage(newPages);

            logger.Info("DetectingKeywords()");
            // Найти кейворды на странице
            var personPageRanks = DetectingKeywords(downloadPages);

            logger.Info("Insert DB");
            // Сохранить результаты в БД
            AddPersonPageRankInStorage(personPageRanks);
        }

        private IEnumerable<Page> FetchingPages(int siteId)
        {
            return storageService.GetPagesbySite(siteId);
        }

        private IDictionary<Page, string> DownloadAll(IEnumerable<Page> pages)
        {
            IDictionary<Page, string> downloadPages = new Dictionary<Page, string>();

            foreach (Page page in pages)
            {
                var content = downloadService.Download(page.Uri);
                page.LastScanDate = DateTime.Now;
                downloadPages.Add(page, content);
            }

            return downloadPages;
        }

        private IEnumerable<string> FetchingUrls(IDictionary<Page, string> pages)
        {
            return urlService.GetAllUrls(pages);
        }

        private IEnumerable<Page> BuildPages(Site site, IEnumerable<string> urls)
        {
            IList<Page> pages = new List<Page>();

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

        private void AddPagesInStorage(IEnumerable<Page> pages)
        {
            var takePages = pages.Take(50);

            storageService.InsertPages(takePages);
        }

        private void AddPersonPageRankInStorage(IEnumerable<PersonPageRank> personPageRanks)
        {
            storageService.InsertPersonPageRanks(personPageRanks);
        }

        private IEnumerable<PersonPageRank> DetectingKeywords(IDictionary<Page, string> downloadPages)
        {
            List<PersonPageRank> personPageRanks = new List<PersonPageRank>();

            foreach (KeyValuePair<Page, string> page in downloadPages)
            {
                var ranks = crawlerPersonRankService.GetPersonPageRanks(page);
                personPageRanks.AddRange(ranks);
            }

            return personPageRanks;
        }
    }
}