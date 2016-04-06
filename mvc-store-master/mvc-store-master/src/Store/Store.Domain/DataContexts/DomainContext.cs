using Store.Domain.Entities;
using System.Data.Entity;
using System.Diagnostics;

namespace Store.Domain.DataContexts
{
    public class DomainContext : DbContext
    {
        public DomainContext()
            : base("DefaultConnection")
        {
            Database.Log = sql => Debug.Write(sql);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
