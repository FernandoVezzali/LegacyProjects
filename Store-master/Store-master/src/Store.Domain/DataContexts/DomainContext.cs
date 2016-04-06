using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DbSet<User> Users { get; set; }
    }
}
