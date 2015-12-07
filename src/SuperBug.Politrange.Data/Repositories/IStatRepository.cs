using System;
using System.Collections.Generic;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public interface IStatRepository
    {
        IEnumerable<PersonPageRank> GetPageRanksBySite(int siteId);
        IEnumerable<PersonPageRank> GetPageRanksByRangeDate(int siteId, DateTime beginDate, DateTime endDate);
    }
}