using System;
using System.Collections.Generic;
using System.Linq;
using SuperBug.Politrange.Data.Repositories;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Crawler.Services
{
    public interface IStorageService
    {
        IEnumerable<Site> GetSites();
        IEnumerable<Page> GetPagesbySite(int siteId);
        void UpdatePage(Page page);
        int InsertPages(IEnumerable<Page> pages);
        int InsertRanks(IEnumerable<PersonPageRank> personPageRanks);
        IEnumerable<Page> GetManyPages(Func<Page, bool> where);
    }

    public class StorageService: IStorageService
    {
        private readonly IPageRepository pageRepository;
        private readonly IPersonPageRankRepository personPageRankRepository;
        private readonly ISiteRepository siteRepository;

        public StorageService(
            ISiteRepository siteRepository,
            IPageRepository pageRepository,
            IPersonPageRankRepository personPageRankRepository)
        {
            this.siteRepository = siteRepository;
            this.pageRepository = pageRepository;
            this.personPageRankRepository = personPageRankRepository;
        }

        public IEnumerable<Site> GetSites()
        {
            return siteRepository.GetAll().ToList();
        }

        public IEnumerable<Page> GetPagesbySite(int siteId)
        {
            return pageRepository.GetMany(x => x.SiteId == siteId && x.LastScanDate == null).ToList();
        }

        public int InsertPages(IEnumerable<Page> pages)
        {
            int countSaved = 0;

            if (pages.Any())
            {
                countSaved = pageRepository.Insert(pages);
            }

            return countSaved;
        }

        public int InsertRanks(IEnumerable<PersonPageRank> personPageRanks)
        {
            int countSaved = 0;

            if (personPageRanks.Any())
            {
                countSaved = personPageRankRepository.Insert(personPageRanks);
            }

            return countSaved;
        }

        public IEnumerable<Page> GetManyPages(Func<Page, bool> where)
        {
            return pageRepository.GetManyIncludeSite(where).ToList();
        }

        public void UpdatePage(Page page)
        {
            pageRepository.Update(page);
        }
    }
}