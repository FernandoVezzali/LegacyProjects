using System.Collections.Generic;
using codesnippets.Models;

namespace codesnippets.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var cSharpLanguageVersions = new List<LanguageVersion>
            {
                new LanguageVersion() {Id = 1, Version = "1.0"},
                new LanguageVersion() {Id = 2, Version = "1.2"},
                new LanguageVersion() {Id = 3, Version = "2.0"},
                new LanguageVersion() {Id = 4, Version = "3.0"},
                new LanguageVersion() {Id = 5, Version = "4.0"},
                new LanguageVersion() {Id = 6, Version = "5.0"},
                new LanguageVersion() {Id = 7, Version = "6.0"}
            };

            var jsLanguageVersions = new List<LanguageVersion>
            {
                new LanguageVersion() {Id = 1, Version = "1.0"},
                new LanguageVersion() {Id = 2, Version = "1.1"},
                new LanguageVersion() {Id = 3, Version = "1.2"},
                new LanguageVersion() {Id = 4, Version = "1.3"},
                new LanguageVersion() {Id = 5, Version = "1.4"},
                new LanguageVersion() {Id = 6, Version = "1.5"},
                new LanguageVersion() {Id = 7, Version = "1.6"},
                new LanguageVersion() {Id = 8, Version = "1.7"},
                new LanguageVersion() {Id = 9, Version = "1.8"},
                new LanguageVersion() {Id = 10, Version = "1.8.1"},
                new LanguageVersion() {Id = 11, Version = "1.8.2"},
                new LanguageVersion() {Id = 12, Version = "1.8.5"}
            };

            context.Language.AddOrUpdate(
              p => p.Name,
              new Language { Name = "CSharp", LanguageVersions = cSharpLanguageVersions }
              ,new Language { Name = "JavaScript", LanguageVersions = jsLanguageVersions }
            );
        }
    }
}
