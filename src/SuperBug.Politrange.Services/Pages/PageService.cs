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

        public IEnumerable<Page> GetPages()
        {
            return pageRepository.GetPages();
        }

        public Page AddPage(Page page)
        { 
            return pageRepository.AddPage(page);
        }

        public bool RemovePage(int id)
        {
            return pageRepository.DeletePage(id);
        }
    }

    public interface IPageService
    {
        IEnumerable<Page> GetPages();
        Page AddPage(Page page);
        bool RemovePage(int id);
    }
}