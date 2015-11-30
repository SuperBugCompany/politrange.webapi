using System.Collections.Generic;
using System.Linq;
using SuperBug.Politrange.Data.Repositories;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Fakes.Repositories
{
    public class KeywordRepositoryFake: IKeywordRepository
    {
        private List<Keyword> keywords;

        public KeywordRepositoryFake()
        {
            PopulateKeywords();
        }

        public IEnumerable<Keyword> GetKeywords()
        {
            return keywords;
        }

        public Keyword GetKeywordById(int id)
        {
            return keywords.Find(x => x.KeywordId == id);
        }

        public Keyword AddKeyword(Keyword keyword)
        {
            keyword.KeywordId = keywords.Max(x => x.KeywordId) + 1;
            keywords.Add(keyword);

            return keyword;
        }

        public bool DeleteKeyword(int id)
        {
            bool isDeleted = false;

            var keyword = GetKeywordById(id);

            if (keyword != null)
            {
                keywords.Remove(keyword);
                isDeleted = true;
            }

            return isDeleted;
        }

        private void PopulateKeywords()
        {
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
                    Name = "Шойгу"
                }
            };

            keywords = new List<Keyword>()
            {
                new Keyword()
                {
                    KeywordId = 1,
                    Name = "Медведеву",
                    Person = persons[0]
                },
                new Keyword()
                {
                    KeywordId = 2,
                    Name = "Медведева",
                    Person = persons[0]
                },
                new Keyword()
                {
                    KeywordId = 3,
                    Name = "Шойгу",
                    Person = persons[1]
                }
            };
        }
    }
}