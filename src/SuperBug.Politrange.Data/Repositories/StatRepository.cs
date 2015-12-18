using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public class StatRepository: IStatRepository
    {
        public IEnumerable<PersonPageRank> GetPageRanksBySite(int siteId)
        {
            using (var context = new PolitrangeContext())
            {
                return context.PersonPageRanks.Where(x => x.Page.SiteId == siteId).Include(x => x.Person);
            }
        }

        public IEnumerable<PersonPageRank> GetPageRanksByRangeDate(int siteId, DateTime beginDate, DateTime endDate)
        {
            using (var context = new PolitrangeContext())
            {
                return
                    context.PersonPageRanks.Where(x => x.Page.SiteId == siteId)
                           .Where(d => (d.Page.FoundDate >= beginDate && d.Page.FoundDate <= endDate))
                           .Include(p => p.Person);
            }
        }
    }
}