using System.Collections.Generic;
using System.Linq;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public class SiteRepository: ISiteRepository
    {
        private readonly IPolitrangeContext context;

        public SiteRepository(IPolitrangeContext context)
        {
            this.context = context;
        }

        public IEnumerable<Site> GetAllSite()
        {
            return context.Sites.ToList();
        }

        public Site GetSiteById(int id)
        {
            return context.Sites.FirstOrDefault(x => x.SiteId == id);
        }

        public Site AddSite(Site site)
        {
            site = context.Sites.Add(site);
            context.SaveChanges();

            return site;
        }

        public bool DeleteSite(int id)
        {
            bool isDeleted = false;

            //            Site site = new Site(){SiteId = id};
            //            site = context.Sites.Attach(site);
            Site site = context.Sites.Find(id);
            
            if (site != null)
            {
                context.Sites.Remove(site);
                context.SaveChanges();

                isDeleted = true;
            }

            return isDeleted;
        }
    }
}