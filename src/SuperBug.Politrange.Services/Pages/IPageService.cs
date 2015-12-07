using System.Collections.Generic;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Services.Pages
{
    public interface IPageService
    {
        IEnumerable<Page> GetAll();
        Page Add(Page page);
        bool Remove(int id);
        IEnumerable<Page> GetBySiteId(int siteId);
    }
}