using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.DataContexts
{
    public class StoreContext : IdentityDbContext<ApplicationUser>
    {
        public StoreContext()
            : base("DefaultConnection")
        {
            Database.Log = sql => Debug.Write(sql);
        }

        public DbSet<Log> Log { get; set; }

        //public System.Data.Entity.DbSet<Store.Models.Category> Categories { get; set; }
    }
}
