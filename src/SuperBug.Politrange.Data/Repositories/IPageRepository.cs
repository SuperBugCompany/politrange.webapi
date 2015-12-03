using System;
using System.Collections.Generic;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public interface IPageRepository
    {
        IEnumerable<Page> GetPages();
        IEnumerable<Page> GetMany(Func<Page, bool> where);
        Page GetPageById(int id);
        Page AddPage(Page page);
        bool DeletePage(int id); 
    }
}