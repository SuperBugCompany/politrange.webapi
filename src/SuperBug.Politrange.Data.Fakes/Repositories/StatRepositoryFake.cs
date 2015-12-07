using System;
using System.Collections.Generic;
using System.Linq;
using SuperBug.Politrange.Data.Repositories;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Fakes.Repositories
{
    public class StatRepositoryFake: IStatRepository
    {
        private List<PersonPageRank> personPageRanks;

        public StatRepositoryFake()
        {
            Populate();
        }

        public IEnumerable<PersonPageRank> GetPageRanksBySite(int siteId)
        {
            return personPageRanks.Where(x => x.Page.Site.SiteId == siteId);
        }

        public IEnumerable<PersonPageRank> GetPageRanksByRangeDate(int siteId, DateTime beginDate, DateTime endDate)
        {
            return
                personPageRanks.Where(x => x.Page.Site.SiteId == siteId)
                               .Where(d => (d.Page.FoundDate >= beginDate && d.Page.FoundDate <= endDate));
        }

        private void Populate()
        {
            #region Data fakes

            var sites = new List<Site>()
            {
                new Site() {SiteId = 1, Name = "Lenta.ru"},
                new Site() {SiteId = 2, Name = "Gazeta.ru"}
            };

            var pages = new List<Page>()
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
                    PageId = 5,
                    Uri = "www.lenta.ru/new/99999",
                    FoundDate = DateTime.Today,
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

            var persons = new List<Person>()
            {
                new Person()
                {
                    PersonId = 1,
                    Name = "Медведев",
                },
                new Person()
                {
                    PersonId = 3,
                    Name = "Навальный"
                }
            };

            #endregion

            personPageRanks = new List<PersonPageRank>()
            {
                new PersonPageRank()
                {
                    Page = pages[0],
                    Person = persons[0],
                    Rank = 30
                },
                new PersonPageRank()
                {
                    Page = pages[1],
                    Person = persons[0],
                    Rank = 20
                },
                new PersonPageRank()
                {
                    Page = pages[2],
                    Person = persons[0],
                    Rank = 20
                },
                new PersonPageRank()
                {
                    Page = pages[1],
                    Person = persons[1],
                    Rank = 20
                },
                new PersonPageRank()
                {
                    Page = pages[1],
                    Person = persons[1],
                    Rank = 10
                }
            };
        }
    }
}