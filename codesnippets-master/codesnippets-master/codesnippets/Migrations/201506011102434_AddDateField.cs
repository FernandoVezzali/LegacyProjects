namespace codesnippets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Snippets", "Released", c => c.DateTime(nullable: true, defaultValue: DateTime.UtcNow));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Snippets", "Released");
        }
    }
}
