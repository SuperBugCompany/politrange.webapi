using System;
using System.Collections.Generic;
using System.Linq;
using SuperBug.Politrange.Data.Repositories;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Crawler
{
    public interface IStorageService
    {
        IEnumerable<Site> GetSites();
        IEnumerable<Page> GetPagesbySite(int siteId);
        void UpdatePages(IEnumerable<Page> pages);
        void InsertPages(IEnumerable<Page> pages);
        void InsertPersonPageRanks(IEnumerable<PersonPageRank> personPageRanks);
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

        public void UpdatePages(IEnumerable<Page> pages)
        {
            foreach (Page page in pages)
            {
                pageRepository.Update(page);
            }
        }

        public void InsertPages(IEnumerable<Page> pages)
        {
            if (pages.Any())
            {
                pageRepository.Insert(pages);
            }
        }

        public void InsertPersonPageRanks(IEnumerable<PersonPageRank> personPageRanks)
        {
            if (personPageRanks.Any())
            {
                personPageRankRepository.Insert(personPageRanks);
            }
        }

        public IEnumerable<Page> GetManyPages(Func<Page, bool> where)
        {
            return pageRepository.GetMany(where);
        }
    }
}