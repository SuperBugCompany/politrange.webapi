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
            Populate();
        }

        public IEnumerable<Page> GetAll()
        {
            return pages;
        }

        public IEnumerable<Page> GetMany(Func<Page, bool> where)
        {
            return pages.Where(where);
        }

        public Page GetById(int id)
        {
            return pages.Find(x => x.PageId == id);
        }

        public Page Add(Page page)
        {
            page.PageId = pages.Max(x => x.PageId) + 1;
            pages.Add(page);

            return page;
        }

        public bool Update(Page entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;

            var page = GetById(id);

            if (page != null)
            {
                pages.Remove(page);
                isDeleted = true;
            }

            return isDeleted;
        }

        private void Populate()
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
                    Uri = "www.lenta.ru",
                    FoundDate = DateTime.Today.AddYears(-2),
                    LastScanDate = DateTime.Today,
                    Site = sites[0]
                },
                new Page()
                {
                    PageId = 2,
                    Uri = "www.lenta.ru/new/100500",
                    FoundDate = DateTime.Today.AddYears(-2),
                    LastScanDate = DateTime.Today,
                    Site = sites[0]
                },
                new Page()
                {
                    PageId = 3,
                    Uri = "www.gazeta.ru",
                    FoundDate = DateTime.Today.AddYears(-3),
                    LastScanDate = DateTime.Today,
                    Site = sites[1]
                },
                new Page()
                {
                    PageId = 4,
                    Uri = "www.gazeta.ru/new/100500",
                    FoundDate = DateTime.Today.AddYears(-3),
                    LastScanDate = DateTime.Today,
                    Site = sites[1]
                }
            };
        }
    }
}