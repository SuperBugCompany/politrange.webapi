﻿using System;
using System.Collections.Generic;
using System.Linq;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public class PersonPageRankRepository: IPersonPageRankRepository
    {
        public int Insert(IEnumerable<PersonPageRank> entities)
        {
            int size = 100;

            int count = entities.Count();

            int countPaginate = Convert.ToInt32(count / size) + 1;

            int countSaved = 0;

            for (int i = 0; i < countPaginate; i++)
            {
                IEnumerable<PersonPageRank> ranks = entities.Skip(i * size).Take(size);

                using (var context = new PolitrangeContext())
                {
                    foreach (PersonPageRank rank in ranks)
                    {
                        var existRank =
                            context.PersonPageRanks.SingleOrDefault(
                                x => x.Page.PageId == rank.Page.PageId && x.Person.PersonId == rank.Person.PersonId);

                        if (existRank == null)
                        {
                            context.Pages.Attach(rank.Page);
                            context.Persons.Attach(rank.Person);
                            context.PersonPageRanks.Add(rank);
                        }
                    }
                    countSaved += context.SaveChanges();
                }
            }

            return countSaved;
        }
    }
}