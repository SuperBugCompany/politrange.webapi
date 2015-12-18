using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    internal class KeywordRepository: IKeywordRepository
    {
        public IEnumerable<Keyword> GetAll()
        {
            using (var context = new PolitrangeContext())
            {
                return context.Keywords.ToList();
            }
        }

        public Keyword GetById(int id)
        {
            using (var context = new PolitrangeContext())
            {
                return context.Keywords.Find(id);
            }
        }

        public Keyword Add(Keyword entity)
        {
            using (var context = new PolitrangeContext())
            {
                entity = context.Keywords.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public bool Update(Keyword entity)
        {
            bool isUpdated = false;

            using (var context = new PolitrangeContext())
            {
                context.Keywords.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
                if (context.SaveChanges() > 0)
                {
                    isUpdated = true;
                }
            }

            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;

            using (var context = new PolitrangeContext())
            {
                var keyword = context.Keywords.Find(id);
                if (keyword != null)
                {
                    context.Keywords.Remove(keyword);
                    context.SaveChanges();
                    isDeleted = true;
                }
            }

            return isDeleted;
        }

        public IEnumerable<Keyword> GetMany(Func<Keyword, bool> where)
        {
            using (var context = new PolitrangeContext())
            {
                return context.Keywords.Where(where).ToList();
            }
        }
    }
}