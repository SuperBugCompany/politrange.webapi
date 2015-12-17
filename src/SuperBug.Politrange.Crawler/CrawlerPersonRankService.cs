using System.Collections.Generic;
using System.IO;
using System.Linq;
using HtmlAgilityPack;
using SuperBug.Politrange.Data.Repositories;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Crawler
{
    public interface ICrawlerPersonRankService
    {
        IEnumerable<PersonPageRank> GetPersonPageRanks(KeyValuePair<Page, string> page);
    }

    public class CrawlerPersonRankService: ICrawlerPersonRankService
    {
        private readonly IPersonRepository personRepository;

        public CrawlerPersonRankService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public IEnumerable<PersonPageRank> GetPersonPageRanks(KeyValuePair<Page, string> page)
        {
            IList<PersonPageRank> ranks = new List<PersonPageRank>();

            if (page.Key == null
                || string.IsNullOrEmpty(page.Value)
                || IsExtensionUrl(page.Key.Uri))
            {
                return ranks;
            }

            HtmlDocument htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(page.Value);

            var nodes = htmlDocument.DocumentNode.SelectNodes("//p");

            var persons = GetPersons();

            var text = string.Empty;

            foreach (Person person in persons)
            {
                foreach (Keyword keyword in person.Keywords)
                {
                    foreach (HtmlNode node in nodes)
                    {
                        text = node.InnerText;
                        if (text.Contains(keyword.Name))
                        {
                            AddOrUpdateRank(ranks, page.Key, person);
                        }
                    }
                }
            }

            return ranks;
        }

        private IEnumerable<Person> GetPersons()
        {
            return personRepository.GetAll();
        }

        private void AddOrUpdateRank(IList<PersonPageRank> ranks, Page page, Person person)
        {
            var rank = ranks.SingleOrDefault(x => x.Page.PageId == page.PageId && x.Person.PersonId == person.PersonId);

            if (rank == null)
            {
                rank = new PersonPageRank() {Page = page, Person = person};
                ranks.Add(rank);
            }

            rank.Rank ++;
        }

        private bool IsExtensionUrl(string url)
        {
            return Path.HasExtension(url);
        }
    }
}