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

        public Site GetbyId(int id)
        {
            return siteRepository.GetById(id);
        }

        public Site Add(Site site)
        {
            site = siteRepository.Add(site);

            string url = GetUrl(site.Name);

            var page = new Page()
            {
                Uri = url,
                Site = site,
            };

            pageRepository.Add(page);

            return site;
        }

        public bool Update(Site site)
        {
            return siteRepository.Update(site);
        }

        public bool Remove(int id)
        {
            return siteRepository.Delete(id);
        }

        private string GetUrl(string name)
        {
            string url = name.ToLower();

            return url.Contains("www.") ? url : url.Insert(0, "www.");
        }

    }
}