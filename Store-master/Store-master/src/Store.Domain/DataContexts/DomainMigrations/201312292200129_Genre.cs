namespace Store.Domain.DataContexts.DomainMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "FirstGenre", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "FirstGenre");
        }
    }
}
