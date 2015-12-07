using System;
using System.Collections.Generic;
using SuperBug.Politrange.Data.Infrastructure;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public interface IKeywordRepository: IRepository<Keyword>
    {
        IEnumerable<Keyword> GetMany(Func<Keyword,bool> where);
    }
}