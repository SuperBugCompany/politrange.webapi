using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SuperBug.Politrange.Data.Contexts;
using SuperBug.Politrange.Models;

namespace SuperBug.Politrange.Data.Repositories
{
    public class PageRepository: IPageRepository
    {
        public IEnumerable<Page> GetAll()
        {
            using (var context = new PolitrangeContext())
            {
                return context.Pages.ToList();
            }
        }

        public Page GetById(int id)
        {
            using (var context = new PolitrangeContext())
            {
                return context.Pages.Find(id);
            }
        }

        public Page Add(Page entity)
        {
            using (var context = new PolitrangeContext())
            {
                context.Sites.Attach(entity.Site);
                entity = context.Pages.Add(entity);
                context.SaveChanges();
                return entity;
            }
        }

        public bool Update(Page entity)
        {
            bool isUpdated = false;

            using (var context = new PolitrangeContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;

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
                var page = context.Pages.Find(id);
                if (page != null)
                {
                    context.Pages.Remove(page);
                    context.SaveChanges();
                    isDeleted = true;
                }
            }

            return isDeleted;
        }

        public IEnumerable<Page> GetMany(Func<Page, bool> where)
        {
            using (var context = new PolitrangeContext())
            {
                return context.Pages.Where(where).ToList();
            }
        }

        public int Insert(IEnumerable<Page> entities)
        {
            const int size = 100;

            int count = entities.Count();

            int countPaginate = Convert.ToInt32(count / size) + 1;

            int countSaved = 0;

            for (int i = 0; i < countPaginate; i++)
            {
                IEnumerable<Page> pages = entities.Skip(i * size).Take(size);

                using (var context = new PolitrangeContext())
                {
                    context.Sites.Attach(pages.First().Site);

                    foreach (Page page in pages)
                    {
                        var existPage = context.Pages.SingleOrDefault(x => x.Uri.Contains(page.Uri));

                        if (existPage == null)
                        {
                            context.Pages.Add(page);
                        }
                    }

                    countSaved += context.SaveChanges();
                }
            }

            return countSaved;
        }

        public IEnumerable<Page> GetManyIncludeSite(Func<Page, bool> where)
        {
            using (var context = new PolitrangeContext())
            {
                return context.Pages.Include(x => x.Site).Where(@where).Take(100).ToList();
            }
        }
    }
}