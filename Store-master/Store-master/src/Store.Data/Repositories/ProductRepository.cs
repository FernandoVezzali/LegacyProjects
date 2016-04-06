using Store.Domain;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Store.Domain.DataContexts;
using System.Threading.Tasks;

namespace Store.Data
{
    public class ProductRepository : IRepository<Product>
    {
        DomainContext context = new DomainContext();

        public IQueryable<Product> All
        {
            get { return context.Products; }
        }

        public IQueryable<Product> AllIncluding(params Expression<Func<Product, object>>[] includeProperties)
        {
            IQueryable<Product> query = context.Products;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Product Find(int id)
        {
            return context.Products.Find(id);
        }

        public void InsertOrUpdate(Product product)
        {
            if (product.ProductId == default(int))
            {
                // New entity
                context.Products.Add(product);
            }
            else
            {
                // Existing entity
                context.Entry(product).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
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
