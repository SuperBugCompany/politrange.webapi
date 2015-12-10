using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public class PersonRepository: IPersonRepository
    {
        private readonly PolitrangeContext context;

        public PersonRepository(PolitrangeContext context)
        {
            this.context = context;
        }

        public IEnumerable<Person> GetAll()
        {
            return context.Persons.ToList();
        }

        public Person GetById(int id)
        {
            return context.Persons.Find(id);
        }

        public Person Add(Person entity)
        {
            entity = context.Persons.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public bool Update(Person entity)
        {
            bool isUpdated = false;

            context.Persons.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
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
                context.Persons.Remove(person);
                context.SaveChanges();
                isDeleted = true;
            }

            return isDeleted;
        }
    }
}