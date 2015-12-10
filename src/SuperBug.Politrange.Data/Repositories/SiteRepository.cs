using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public class SiteRepository: ISiteRepository
    {
        private readonly PolitrangeContext context;

        public SiteRepository(PolitrangeContext context)
        {
            this.context = context;
        }

        public IEnumerable<Site> GetAll()
        {
            return context.Sites.ToList();
        }

        public Site GetById(int id)
        {
            return context.Sites.Find(id);
        }

        public Site Add(Site entity)
        {
            entity = context.Sites.Add(entity);
            context.SaveChanges();

            return entity;
        }

        public bool Update(Site entity)
        {
            bool isUpdated = false;

            context.Sites.Attach(entity);
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

            var site = GetById(id);

            if (site != null)
            {
                context.Sites.Remove(site);
                context.SaveChanges();

                isDeleted = true;
            }

            return isDeleted;
        }
    }
}