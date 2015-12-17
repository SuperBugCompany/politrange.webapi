using System.Collections.Generic;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Data.Infrastructure;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public interface IPersonPageRankRepository:IRepository<PersonPageRank>
    {
        void Insert(IEnumerable<PersonPageRank> entities);
    }

    public class PersonPageRankRepository: IPersonPageRankRepository
    {
        private readonly PolitrangeContext context;

        public PersonPageRankRepository(PolitrangeContext context)
        {
            this.context = context;
        }

        public IEnumerable<PersonPageRank> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public PersonPageRank GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public PersonPageRank Add(PersonPageRank entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(PersonPageRank entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(IEnumerable<PersonPageRank> entities)
        {
            foreach (PersonPageRank entity in entities)
            {
//                context.Pages.Attach(entity.Page);
//                context.Persons.Attach(entity.Person);
                context.PersonPageRanks.Add(entity);
            }
            context.SaveChanges();
        }
    }
}