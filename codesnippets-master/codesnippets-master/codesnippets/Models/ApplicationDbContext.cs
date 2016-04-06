using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace codesnippets.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ModelDB", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Snippet> Snippets { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<LanguageVersion> LanguageVersion { get; set; }
    }
}