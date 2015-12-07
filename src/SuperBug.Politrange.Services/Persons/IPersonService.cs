using System.Collections.Generic;
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
}