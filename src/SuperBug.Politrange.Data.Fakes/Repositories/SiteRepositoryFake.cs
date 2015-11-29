using System.Collections.Generic;
using System.Linq;
using SuperBug.Politrange.Data.Repositories;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Fakes.Repositories
{
    public class SiteRepositoryFake: ISiteRepository
    {
        private List<Site> sites;

        public SiteRepositoryFake()
        {
            PopulateSites();
        }

        public IEnumerable<Site> GetAllSite()
        {
            return sites;
        }

        public Site GetSiteById(int id)
        {
            return sites.Find(x => x.SiteId == id);
        }

        public bool DeleteSite(int id)
        {
            bool isDelete = false;

            Site site = sites.Find(x => x.SiteId == id);
            if (site != null)
            {
                sites.Remove(site);
                isDelete = true;
            }

            return isDelete;
        }

        public Site AddSite(Site site)
        {
            site.SiteId = sites.Max(x => x.SiteId) + 1;
            sites.Add(site);

            return site;
        }

        private void PopulateSites()
        {
            sites = new List<Site>()
            {
                new Site() {SiteId = 1, Name = "Lenta.ru"},
                new Site() {SiteId = 2, Name = "Gazeta.ru"}
            };
        }
    }
}