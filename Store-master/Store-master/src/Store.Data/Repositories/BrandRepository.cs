using Store.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Store.Domain.DataContexts;
using System.Threading.Tasks;

namespace Store.Data
{
    public class BrandRepository : IRepository<Brand>
    {
        DomainContext context = new DomainContext();

        public IQueryable<Brand> All
        {
            get { return context.Brands; }
        }

        public IQueryable<Brand> AllIncluding(params System.Linq.Expressions.Expression<Func<Brand, object>>[] includeProperties)
        {
            IQueryable<Brand> query = context.Brands;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Brand Find(int id)
        {
            return context.Brands.Find(id);
        }

        public void InsertOrUpdate(Brand entity)
        {
            if (entity.BrandId == default(int))
            {
                // New entity
                context.Brands.Add(entity);
            }
            else
            {
                // Existing entity
                context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var brand = context.Brands.Find(id);
            context.Brands.Remove(brand);
        }

        /*
        public async Task Save()
        {
            await context.SaveChangesAsync();
        }
        */

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
