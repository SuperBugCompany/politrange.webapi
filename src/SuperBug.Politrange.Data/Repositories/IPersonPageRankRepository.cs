﻿using System.Collections.Generic;
using SuperBug.Politrange.Data.Infrastructure;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public interface IPersonPageRankRepository
    {
        int Insert(IEnumerable<PersonPageRank> entities);
    }
}