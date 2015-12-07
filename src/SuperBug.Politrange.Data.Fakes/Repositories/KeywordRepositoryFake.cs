using System;
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
            Populate();
        }

        public IEnumerable<Keyword> GetAll()
        {
            return keywords;
        }

        public Keyword GetById(int id)
        {
            return keywords.Find(x => x.KeywordId == id);
        }

        public Keyword Add(Keyword keyword)
        {
            keyword.KeywordId = keywords.Max(x => x.KeywordId) + 1;

            keywords.Add(keyword);

            return keyword;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;

            var keyword = GetById(id);

            if (keyword != null)
            {
                keywords.Remove(keyword);
                isDeleted = true;
            }

            return isDeleted;
        }

        public IEnumerable<Keyword> GetMany(Func<Keyword, bool> @where)
        {
            return keywords.Where(where);
        }

        public bool Update(Keyword entity)
        {
            bool isUpdated = false;

            var keyword = GetById(entity.KeywordId);

            if (keyword != null)
            {
                keyword.Name = entity.Name;
                isUpdated = true;
            }

            return isUpdated;
        }

        private void Populate()
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
                    PersonId = persons[0].PersonId,
                    Person = persons[0]
                },
                new Keyword()
                {
                    KeywordId = 2,
                    Name = "Медведева",
                    PersonId = persons[0].PersonId,
                    Person = persons[0]
                },
                new Keyword()
                {
                    KeywordId = 3,
                    Name = "Шойгу",
                    PersonId = persons[1].PersonId,
                    Person = persons[1]
                }
            };
        }
    }
}