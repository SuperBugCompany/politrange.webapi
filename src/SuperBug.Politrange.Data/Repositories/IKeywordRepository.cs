using System;
using System.Collections.Generic;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public interface IKeywordRepository
    {
        IEnumerable<Keyword> GetKeywords();
        Keyword GetKeywordById(int id);
        Keyword AddKeyword(Keyword keyword);
        bool DeleteKeyword(int id);
        IEnumerable<Keyword> GetMany(Func<Keyword,bool> where);
    }
}