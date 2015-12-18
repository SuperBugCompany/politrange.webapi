using System;
using System.Collections.Generic;
using System.Linq;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public class PersonPageRankRepository: IPersonPageRankRepository
    {
        public void Insert(IEnumerable<PersonPageRank> entities)
        {
            int size = 100;

            int count = entities.Count();

            int countPaginate = Convert.ToInt32(count / size) + 1;

            for (int i = 0; i < countPaginate; i++)
            {
                IEnumerable<PersonPageRank> ranks = entities.Skip(i * size).Take(size);

                using (var context = new PolitrangeContext())
                {
                    context.Configuration.AutoDetectChangesEnabled = false;

                    foreach (PersonPageRank rank in ranks)
                    {
                        context.Pages.Attach(rank.Page);
                        context.Persons.Attach(rank.Person);
                        context.PersonPageRanks.Add(rank);
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}