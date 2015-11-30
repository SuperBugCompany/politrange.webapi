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
            PopulatePersons();
        }

        public IEnumerable<Person> GetPersons()
        {
            return persons;
        }

        public Person GetPersonById(int id)
        {
            return persons.Find(x => x.PersonId == id);
        }

        public Person AddPerson(Person person)
        {
            person.PersonId = persons.Max(x => x.PersonId) + 1;
            persons.Add(person);

            return person;
        }

        public bool DeletePerson(int id)
        {
            bool isDelete = false;

            Person person = persons.Find(x => x.PersonId == id);
            if (person != null)
            {
                persons.Remove(person);
                isDelete = true;
            }

            return isDelete;
        }

        private void PopulatePersons()
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
                    PersonId = 2,
                    Name = "Навальный"
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