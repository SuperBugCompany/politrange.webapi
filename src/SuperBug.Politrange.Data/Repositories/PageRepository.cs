using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    internal class PageRepository: IPageRepository
    {
        private readonly PolitrangeContext context;

        public PageRepository(PolitrangeContext context)
        {
            this.context = context;
        }

        public IEnumerable<Page> GetAll()
        {
            return context.Pages.ToList();
        }

        public Page GetById(int id)
        {
            return context.Pages.Find(id);
        }

        public Page Add(Page entity)
        {
            entity = context.Pages.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public bool Update(Page entity)
        {
            bool isUpdated = false;

            context.Pages.Attach(entity);
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

            var page = GetById(id);

            if (page != null)
            {
                context.Pages.Remove(page);
                context.SaveChanges();
                isDeleted = true;
            }

            return isDeleted;
        }

        public IEnumerable<Page> GetMany(Func<Page, bool> where)
        {
            return context.Pages.Where(where);
        }
    }
}