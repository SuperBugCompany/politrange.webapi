using System;
using System.Collections.Generic;
using System.Linq;
using SuperBug.Politrange.Data.Repositories;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Fakes.Repositories
{
    public class PageRepositoryFake: IPageRepository
    {
        private List<Page> pages;

        public PageRepositoryFake()
        {
            PopulatePages();
        }

        public IEnumerable<Page> GetPages()
        {
            return pages;
        }

        public Page GetPageById(int id)
        {
            return pages.Find(x => x.PageId == id);
        }

        public Page AddPage(Page page)
        {
            page.PageId = pages.Max(x => x.PageId) + 1;
            pages.Add(page);
            
            return page;
        }

        public bool DeletePage(int id)
        {
            bool isDeleted = false;

            var page = GetPageById(id);

            if (page != null)
            {
                pages.Remove(page);
                isDeleted = true;
            }

            return isDeleted;
        }

        private void PopulatePages()
        {
            var sites = new List<Site>()
            {
                new Site() {SiteId = 1, Name = "Lenta.ru"},
                new Site() {SiteId = 2, Name = "Gazeta.ru"}
            };

            pages = new List<Page>()
            {
                new Page()
                {
                    PageId = 1,
                    Uri = "www.lenta.ru/new/100500",
                    FoundDate = DateTime.Today.AddYears(-2),
                    LastScanDate = DateTime.Today,
                    Site = sites[0]
                },
                new Page()
                {
                    PageId = 2,
                    Uri = "www.gazeta.ru/new/100500",
                    FoundDate = DateTime.Today.AddYears(-3),
                    LastScanDate = DateTime.Today,
                    Site = sites[1]
                }
            };
        }
    }
}