namespace Store.Domain.DataContexts.DomainMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class brand : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BrandId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Brands", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Brands", new[] { "CategoryId" });
            DropTable("dbo.Brands");
        }
    }
}
