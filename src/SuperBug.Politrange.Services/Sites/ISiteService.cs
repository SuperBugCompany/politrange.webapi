using System.Collections.Generic;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Services.Sites
{
    public interface ISiteService
    {
        IEnumerable<Site> GetAll();
        Site GetbyId(int id);
        Site Add(Site site);
        bool Remove(int id);
        bool Update(Site site);
    }
}