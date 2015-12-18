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
    }

    public class StorageService: IStorageService
    {
        private readonly IPageRepository pageRepository;
        private readonly ISiteRepository siteRepository;

        public StorageService(ISiteRepository siteRepository, IPageRepository pageRepository)
        {
            this.siteRepository = siteRepository;
            this.pageRepository = pageRepository;
        }

        public IEnumerable<Site> GetSites()
        {
            return siteRepository.GetAll().ToList();
        }

        public IEnumerable<Page> GetPagesbySite(int siteId)
        {
            return pageRepository.GetMany(x => x.SiteId == siteId && x.LastScanDate == null).ToList();
        }

        public IEnumerable<Page> GetManyPages(Func<Page, bool> where)
        {
            return pageRepository.GetMany(where);
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
    }
}