using System.Collections.Generic;
using SuperBug.Politrange.Data.Repositories;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Services.Persons
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
        Person GetPersonById(int id);
        Person AddPerson(Person person);
        bool RemovePerson(int id);
        IEnumerable<Keyword> GetKeywordsByPersonId(int personId);
    }

    public class PersonService: IPersonService
    {
        private readonly IKeywordRepository keywordRepository;
        private readonly IPersonRepository personRepository;

        public PersonService(IPersonRepository personRepository, IKeywordRepository keywordRepository)
        {
            this.personRepository = personRepository;
            this.keywordRepository = keywordRepository;
        }

        public IEnumerable<Person> GetAll()
        {
            return personRepository.GetPersons();
        }

        public Person GetPersonById(int id)
        {
            return personRepository.GetPersonById(id);
        }

        public Person AddPerson(Person person)
        {
            return personRepository.AddPerson(person);
        }

        public bool RemovePerson(int id)
        {
            return personRepository.DeletePerson(id);
        }

        public IEnumerable<Keyword> GetKeywordsByPersonId(int personId)
        {
            return keywordRepository.GetMany(x => x.Person.PersonId == personId);
        }
    }
}