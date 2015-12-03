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
            return siteRepository.GetAllSite();
        }

        public Site GetSitebyId(int id)
        {
            return siteRepository.GetSiteById(id);
        }

        public Site AddSite(Site site)
        {
            return siteRepository.AddSite(site);
        }

        public bool Delete(int id)
        {
            return siteRepository.DeleteSite(id);
        }

        public IEnumerable<Page> GetPagesBySiteId(int siteId)
        {
            return pageRepository.GetMany(x => x.Site.SiteId == siteId);
        }
    }
}