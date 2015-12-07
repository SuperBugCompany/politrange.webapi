using System.Collections.Generic;
using SuperBug.Politrange.Data.Repositories;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Services.Pages
{
    public class PageService: IPageService
    {
        private readonly IPageRepository pageRepository;

        public PageService(IPageRepository pageRepository)
        {
            this.pageRepository = pageRepository;
        }

        public IEnumerable<Page> GetAll()
        {
            return pageRepository.GetAll();
        }

        public Page Add(Page page)
        { 
            return pageRepository.Add(page);
        }

        public bool Remove(int id)
        {
            return pageRepository.Delete(id);
        }

        public IEnumerable<Page> GetBySiteId(int siteId)
        {
            return pageRepository.GetMany(x => x.Site.SiteId == siteId);
        }
    }

    public interface IPageService
    {
        IEnumerable<Page> GetAll();
        Page Add(Page page);
        bool Remove(int id);
        IEnumerable<Page> GetBySiteId(int siteId);
    }
}