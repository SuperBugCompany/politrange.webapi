﻿using System;
using System.Collections.Generic;
using SuperBug.Politrange.Data.Infrastructure;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public interface IPageRepository: IRepository<Page>
    {
        IEnumerable<Page> GetMany(Func<Page, bool> where);
        int Insert(IEnumerable<Page> entities);
        IEnumerable<Page> GetManyIncludeSite(Func<Page, bool> where);
    }
}