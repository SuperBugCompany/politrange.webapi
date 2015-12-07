using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using SuperBug.Politrange.Data.Repositories;
using SuperBug.Politrange.Models;
using SuperBug.Politrange.Services.States;
using Xunit;
using Xunit.Abstractions;

namespace SuperBug.Politrange.Service.UnitTest
{
    public class StatServiceTest
    {
        private readonly ITestOutputHelper output;

        private Mock<IStatRepository> statRepositoryMock;
        private IStatService statService;

        public StatServiceTest(ITestOutputHelper output)
        {
            this.output = output;
            statRepositoryMock = new Mock<IStatRepository>();

            statService = new StatService(statRepositoryMock.Object);
        }

        [Fact]
        public void ShouldBeReturnGroupByPersonSumRanks()
        {
            //arrange
            statRepositoryMock.Setup(m => m.GetPageRanksBySite(It.IsAny<int>())).Returns(GetRatings);

            //act
            var result = statService.GetRanksBySite(1).ToList();

            //assert
            Assert.Equal(result[0].Rank, 30);

            foreach (PersonPageRank item in result)
            {
                output.WriteLine("{0}: {1}", item.Person.Name, item.Rank);
            }
        }

        [Fact]
        public void ShouldBeReturnGroupDateByRangeDate()
        {
            //arrange
            var ratings = GetRatings();
            var beginDate = new DateTime(2012, 1, 1);
            var endDate = new DateTime(2014, 1, 1);

            statRepositoryMock.Setup(m => m.GetPageRanksByRangeDate(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                              .Returns(ratings.Where(d => (d.Page.FoundDate >= beginDate && d.Page.FoundDate <= endDate)));

            //act
            var result = statService.GetRanksByRangeDate(1, beginDate, endDate);

            //assert
            foreach (PersonPageRank item in result)
            {
                output.WriteLine("{0}, {1}, {2}", item.Person.Name, item.Rank, item.Page.FoundDate);
            }
        }

        #region Data for test

        private IEnumerable<PersonPageRank> GetRatings()
        {
            var sites = new List<Site>()
            {
                new Site() {Name = "Lenta.ru"},
                new Site() {Name = "Gazeta.ru"}
            };

            var persons = new List<Person>()
            {
                new Person() {Name = "Медведев"},
                new Person() {Name = "Навальный"}
            };

            var pages = new List<Page>()
            {
                new Page()
                {
                    Uri = "www.lenta.ru",
                    Site = sites[0],
                    FoundDate = new DateTime(2011, 1, 1),
                    LastScanDate = DateTime.Today
                },
                new Page()
                {
                    Uri = "www.lenta.ru/new/1",
                    Site = sites[0],
                    FoundDate = new DateTime(2012, 1, 1),
                    LastScanDate = DateTime.Today
                },
                new Page()
                {
                    Uri = "www.lenta.ru/new/2",
                    Site = sites[0],
                    FoundDate = new DateTime(2013, 1, 1),
                    LastScanDate = DateTime.Today
                },
                new Page()
                {
                    Uri = "www.lenta.ru/new/2",
                    Site = sites[0],
                    FoundDate = new DateTime(2015, 1, 1),
                    LastScanDate = DateTime.Today
                }
            };

            var ratings = new List<PersonPageRank>()
            {
                new PersonPageRank()
                {
                    Page = pages[0],
                    Person = persons[0],
                    Rank = 10
                },
                new PersonPageRank()
                {
                    Page = pages[1],
                    Person = persons[0],
                    Rank = 10
                },
                new PersonPageRank()
                {
                    Page = pages[0],
                    Person = persons[1],
                    Rank = 10
                },
                new PersonPageRank()
                {
                    Page = pages[2],
                    Person = persons[0],
                    Rank = 10
                },
                new PersonPageRank()
                {
                    Page = pages[1],
                    Person = persons[1],
                    Rank = 10
                },
                new PersonPageRank()
                {
                    Page = pages[3],
                    Person = persons[1],
                    Rank = 10
                }
            };

            return ratings;
        }

        #endregion
    }
}