namespace Store.Domain.DataContexts.StoreMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Log : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 4000),
                        dbData = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Movies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Logs");
        }
    }
}
