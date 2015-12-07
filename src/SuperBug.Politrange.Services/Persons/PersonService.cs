using System.Collections.Generic;
using SuperBug.Politrange.Data.Repositories;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Services.Persons
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
        Person GetById(int id);
        Person Add(Person person);
        bool Update(Person person);
        bool Remove(int id);
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
            return personRepository.GetAll();
        }

        public Person GetById(int id)
        {
            return personRepository.GetById(id);
        }

        public Person Add(Person person)
        {
            return personRepository.Add(person);
        }

        public bool Update(Person person)
        {
            return personRepository.Update(person);
        }

        public bool Remove(int id)
        {
            return personRepository.Delete(id);
        }
    }
}