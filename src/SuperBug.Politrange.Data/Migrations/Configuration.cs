using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Migrations
{
    internal sealed class Configuration: DbMigrationsConfiguration<SuperBug.Politrange.Data.Contexts.PolitrangeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SuperBug.Politrange.Data.Contexts.PolitrangeContext context)
        {
            IEnumerable<Person> persons = new List<Person>()
            {
                new Person() {Name = "Медведев"},
                new Person() {Name = "Навальный"}
            };

            persons = context.Persons.AddRange(persons);
            Save(context);

            var keywords = new List<Keyword>()
            {
                new Keyword()
                {
                    Name = "Медведеву",
                    Person = persons.First()
                },
                new Keyword()
                {
                    Name = "Медведева",
                    Person = persons.First()
                },
                new Keyword()
                {
                    Name = "Навального",
                    Person = persons.Last()
                },
                new Keyword()
                {
                    Name = "Навальному",
                    Person = persons.Last()
                }
            };

            context.Keywords.AddRange(keywords);
            context.SaveChanges();

            IEnumerable<Site> sites = new List<Site>()
            {
                new Site() {Name = "Lenta.ru"},
                new Site() {Name = "Gazeta.ru"}
            };

            sites = context.Sites.AddRange(sites);
            Save(context);

            IEnumerable<Page> pages = new List<Page>()
            {
                new Page()
                {
                    Uri = "www.lenta.ru",
                    Site = sites.First(),
                    FoundDate = new DateTime(2011, 1, 1),
                    LastScanDate = DateTime.Today
                },
                new Page()
                {
                    Uri = "www.gazeta.ru",
                    Site = sites.Last(),
                    FoundDate = new DateTime(2012, 1, 1),
                    LastScanDate = DateTime.Today
                }
            };

            pages = context.Pages.AddRange(pages);
            Save(context);

            var ratings = new List<PersonPageRank>()
            {
                new PersonPageRank()
                {
                    Page = pages.First(),
                    Person = persons.First(),
                    Rank = 20
                },
                new PersonPageRank()
                {
                    Page = pages.Last(),
                    Person = persons.First(),
                    Rank = 20
                },
                new PersonPageRank()
                {
                    Page = pages.First(),
                    Person = persons.Last(),
                    Rank = 10
                },
                new PersonPageRank()
                {
                    Page = pages.Last(),
                    Person = persons.Last(),
                    Rank = 10
                }
            };

            context.PersonPageRanks.AddRange(ratings);
            Save(context);
        }

        private void Save(PolitrangeContext context)
        {
            context.SaveChanges();
        }
    }
}