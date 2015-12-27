using System;
using System.Collections.Generic;
using SuperBug.Politrange.Api.Models.Models;
using SuperBug.Politrange.Api.Models.ViewModels;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Services.States
{
    public interface IStatService
    {
        IEnumerable<PersonPageRank> GetRanksBySite(int id);
        IEnumerable<RangeDatePersonRank> GetRanksByRangeDate(int id, DateTime beginDate, DateTime endDate);
    }
}