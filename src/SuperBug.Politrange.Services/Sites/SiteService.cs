using System.Collections.Generic;
using SuperBug.Politrange.Data.Repositories;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Services.Sites
{
    public class SiteService: ISiteService
    {
        private readonly IPageRepository pageRepository;
        private readonly ISiteRepository siteRepository;

        public SiteService(ISiteRepository siteRepository, IPageRepository pageRepository)
        {
            this.siteRepository = siteRepository;
            this.pageRepository = pageRepository;
        }

        public IEnumerable<Site> GetAll()
        {
            return siteRepository.GetAll();
        }

        public Site GetSitebyId(int id)
        {
            return siteRepository.GetById(id);
        }

        public Site AddSite(Site site)
        {
            return siteRepository.Add(site);
        }

        public bool Update(Site site)
        {
            return siteRepository.Update(site);
        }

        public bool Delete(int id)
        {
            return siteRepository.Delete(id);
        }

        public IEnumerable<Page> GetPagesBySiteId(int siteId)
        {
            return pageRepository.GetMany(x => x.Site.SiteId == siteId);
        }
    }
}