namespace codesnippets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class language : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LanguageVersions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Version = c.String(),
                        Language_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.Language_Id)
                .Index(t => t.Language_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LanguageVersions", "Language_Id", "dbo.Languages");
            DropIndex("dbo.LanguageVersions", new[] { "Language_Id" });
            DropTable("dbo.LanguageVersions");
            DropTable("dbo.Languages");
        }
    }
}
