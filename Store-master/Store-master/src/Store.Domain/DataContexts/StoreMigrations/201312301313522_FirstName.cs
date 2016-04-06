namespace Store.Domain.DataContexts.StoreMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 4000));
            DropColumn("dbo.AspNetUsers", "FavoriteBook");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "FavoriteBook", c => c.String(maxLength: 4000));
            DropColumn("dbo.AspNetUsers", "FirstName");
        }
    }
}
