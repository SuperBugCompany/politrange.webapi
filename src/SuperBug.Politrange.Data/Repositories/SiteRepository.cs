using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public class SiteRepository: ISiteRepository
    {
        public IEnumerable<Site> GetAll()
        {
            using (var context = new PolitrangeContext())
            {
                return context.Sites.ToList();
            }
        }

        public Site GetById(int id)
        {
            using (var context = new PolitrangeContext())
            {
                return context.Sites.Find(id);
            }
        }

        public Site Add(Site entity)
        {
            using (var context = new PolitrangeContext())
            {
                entity = context.Sites.Add(entity);
                context.SaveChanges();

                return entity;
            }
        }

        public bool Update(Site entity)
        {
            bool isUpdated = false;

            using (var context = new PolitrangeContext())
            {
                context.Sites.Attach(entity);
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
                var site = context.Sites.Find(id);

                if (site != null)
                {
                    context.Sites.Remove(site);
                    context.SaveChanges();

                    isDeleted = true;
                }
            }

            return isDeleted;
        }
    }
}