using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public class PersonRepository: IPersonRepository
    {
        public IEnumerable<Person> GetAll()
        {
            using (var context = new PolitrangeContext())
            {
                return context.Persons.ToList();
            }
        }

        public Person GetById(int id)
        {
            using (var context = new PolitrangeContext())
            {
                return context.Persons.Find(id);
            }
        }

        public Person Add(Person entity)
        {
            using (var context = new PolitrangeContext())
            {
                entity = context.Persons.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public bool Update(Person entity)
        {
            bool isUpdated = false;

            using (var context = new PolitrangeContext())
            {
                context.Persons.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;

                if (context.SaveChanges() > 0)
                {
                    isUpdated = true;
                }
            }

            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;

            using (var context = new PolitrangeContext())
            {
                var person = context.Persons.Find(id);

                if (person != null)
                {
                    context.Persons.Remove(person);
                    context.SaveChanges();
                    isDeleted = true;
                }
            }

            return isDeleted;
        }
    }
}