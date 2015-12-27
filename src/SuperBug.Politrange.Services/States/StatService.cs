using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using SuperBug.Politrange.Api.Models.Models;
using SuperBug.Politrange.Api.Models.ViewModels;
using SuperBug.Politrange.Data.Repositories;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Services.States
{
    public class StatService: IStatService
    {
        private readonly IStatRepository statRepository;

        public StatService(IStatRepository statRepository)
        {
            this.statRepository = statRepository;
        }

        //Todo: Bad logic
        public IEnumerable<PersonPageRank> GetRanksBySite(int id)
        {
            IEnumerable<PersonPageRank> ranks = statRepository.GetPageRanksBySite(id);

            return ranks.GroupBy(x => x.Person).Select(s => new PersonPageRank() {Person = s.Key, Rank = s.Sum(e => e.Rank)});
        }

        public IEnumerable<RangeDatePersonRank> GetRanksByRangeDate(int id, DateTime beginDate, DateTime endDate)
        {
            IEnumerable<PersonPageRank> ranks = statRepository.GetPageRanksByRangeDate(id, beginDate, endDate);

            var groupRanks =
                ranks.GroupBy(g => g.Page.FoundDate)
                     .Select(
                         s =>
                             new RangeDatePersonRank()
                             {
                                  FoundDate = s.Key.Value,
                                  PersonPageRanks = s.GroupBy(p => p.Person).Select(pageRanks => new PersonPageRank() { Person = pageRanks.Key, Rank = pageRanks.Sum(e => e.Rank) })
                             });

            return groupRanks;
        }
    }
}