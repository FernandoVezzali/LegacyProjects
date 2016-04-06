using Store.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Store.Domain.DataContexts;
using System.Threading.Tasks;

namespace Store.Data
{
    public class CategoryRepository : IRepository<Category>
    {
        DomainContext context = new DomainContext();

        public IQueryable<Category> All
        {
            get { return context.Categories; }
        }

        public IQueryable<Category> AllIncluding(params Expression<Func<Category, object>>[] includeProperties)
        {
            IQueryable<Category> query = context.Categories;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Category Find(int id)
        {
            return context.Categories.Find(id);
        }

        public void InsertOrUpdate(Category category)
        {
            if (category.CategoryId == default(int))
            {
                // New entity
                context.Categories.Add(category);
            }
            else
            {
                // Existing entity
                context.Entry(category).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
        }

        /*public async Task Save()
        {
            await context.SaveChangesAsync();
        }*/

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
