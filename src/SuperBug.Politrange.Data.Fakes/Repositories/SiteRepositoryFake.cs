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
            Populate();
        }

        public IEnumerable<Site> GetAll()
        {
            return sites;
        }

        public Site GetById(int id)
        {
            return sites.Find(x => x.SiteId == id);
        }

        public bool Update(Site entity)
        {
            bool isUpdated = false;

            var site = GetById(entity.SiteId);

            if (site != null)
            {
                site.Name = entity.Name;
                isUpdated = true;
            }

            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDelete = false;

            var site = GetById(id);

            if (site != null)
            {
                sites.Remove(site);
                isDelete = true;
            }

            return isDelete;
        }

        public Site Add(Site site)
        {
            site.SiteId = sites.Max(x => x.SiteId) + 1;
            sites.Add(site);

            return site;
        }

        private void Populate()
        {
            sites = new List<Site>()
            {
                new Site() {SiteId = 1, Name = "Lenta.ru"},
                new Site() {SiteId = 2, Name = "Gazeta.ru"}
            };
        }
    }
}