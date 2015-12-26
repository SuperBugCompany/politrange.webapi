using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Autofac.Extras.NLog;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public class PersonPageRankRepository: IPersonPageRankRepository
    {
        private readonly ILogger logger;

        public PersonPageRankRepository(ILogger logger)
        {
            this.logger = logger;
        }

        public int Insert(IEnumerable<PersonPageRank> entities)
        {
            int size = 100;

            int count = entities.Count();

            int countPaginate = Convert.ToInt32(count / size) + 1;

            int countSaved = 0;

            for (int i = 0; i < countPaginate; i++)
            {
                IEnumerable<PersonPageRank> ranks = entities.Skip(i * size).Take(size);

                try
                {
                    using (var context = new PolitrangeContext())
                    {
                        foreach (PersonPageRank rank in ranks)
                        {
                            var existRank =
                                context.PersonPageRanks.SingleOrDefault(
                                    x => x.PageId == rank.PageId && x.PersonId == rank.PersonId);

                            if (existRank == null)
                            {
                                context.PersonPageRanks.Add(rank);
                            }
                        }
                        countSaved += context.SaveChanges();
                    }
                }
                catch (Exception exception)
                {
                    logger.Error(exception.Message);
                }

            }

            return countSaved;
        }
    }
}