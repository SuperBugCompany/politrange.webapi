﻿using System.Collections.Generic;

namespace SuperBug.Politrange.Data.Infrastructure
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        bool Delete(T entity);
    }
}