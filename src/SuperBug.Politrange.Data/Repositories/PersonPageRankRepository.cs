using System.Collections.Generic;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public class PersonPageRankRepository: IPersonPageRankRepository
    {
        public void Insert(IEnumerable<PersonPageRank> entities)
        {
            using (var context = new PolitrangeContext())
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
}