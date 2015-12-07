using System.Collections.Generic;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Services.Keywords
{
    public interface IKeywordService
    {
        IEnumerable<Keyword> GetAll();
        Keyword Add(Keyword keyword);
        bool Remove(int id);
        bool Update(Keyword keyword);
        IEnumerable<Keyword> GetByPersonId(int personId);
    }
}