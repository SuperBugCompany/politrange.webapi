using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    class KeywordRepository: IKeywordRepository
    {
        private readonly PolitrangeContext context;

        public KeywordRepository(PolitrangeContext context)
        {
            this.context = context;
        }

        public IEnumerable<Keyword> GetAll()
        {
            return context.Keywords.ToList();
        }

        public Keyword GetById(int id)
        {
            return context.Keywords.Find(id);
        }

        public Keyword Add(Keyword entity)
        {
            entity = context.Keywords.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public bool Update(Keyword entity)
        {
            bool isUpdated = false;

            context.Keywords.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;

            if (context.SaveChanges() > 0)
            {
                isUpdated = true;
            }

            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;

            var keyword = GetById(id);

            if (keyword != null)
            {
                context.Keywords.Remove(keyword);
                context.SaveChanges();
                isDeleted = true;
            }

            return isDeleted;
        }

        public IEnumerable<Keyword> GetMany(Func<Keyword, bool> where)
        {
            return context.Keywords.Where(where);
        }
    }
}