using System.Collections.Generic;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    class PersonRepository: IPersonRepository
    {
        public IEnumerable<Person> GetPersons()
        {
            throw new System.NotImplementedException();
        }

        public Person GetPersonById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Person AddPerson(Person person)
        {
            throw new System.NotImplementedException();
        }

        public bool DeletePerson(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}