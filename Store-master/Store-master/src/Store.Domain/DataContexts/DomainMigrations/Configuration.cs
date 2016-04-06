using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Store.Domain.DataContexts.DomainMigrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Store.Domain.DataContexts.DomainContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\DomainMigrations";
        }

        protected override void Seed(Store.Domain.DataContexts.DomainContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
