using System.Collections.Generic;
using System.Linq;
using SuperBug.Politrange.Data.Repositories;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Fakes.Repositories
{
    public class PersonRepositoryFake: IPersonRepository
    {
        private List<Person> persons;

        public PersonRepositoryFake()
        {
            Populate();
        }

        public IEnumerable<Person> GetAll()
        {
            return persons;
        }

        public Person GetById(int id)
        {
            return persons.Find(x => x.PersonId == id);
        }

        public Person Add(Person person)
        {
            person.PersonId = persons.Max(x => x.PersonId) + 1;
            persons.Add(person);

            return person;
        }

        public bool Update(Person entity)
        {
            bool isUpdated = false;

            var person = GetById(entity.PersonId);

            if (person != null)
            {
                person.Name = entity.Name;
                isUpdated = true;
            }

            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;

            var person = GetById(id);
            if (person != null)
            {
                persons.Remove(person);
                isDeleted = true;
            }

            return isDeleted;
        }

        private void Populate()
        {
            persons = new List<Person>()
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
        }
    }
}