using System.Collections.Generic;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetPersons();
        Person GetPersonById(int id);
        Person AddPerson(Person person);
        bool DeletePerson(int id);
    }
}