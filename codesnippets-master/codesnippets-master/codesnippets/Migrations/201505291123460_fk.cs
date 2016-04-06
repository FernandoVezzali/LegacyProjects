namespace codesnippets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Snippets", "SelectedLanguageId", c => c.Int(nullable: false));
            DropColumn("dbo.Snippets", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Snippets", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Snippets", "SelectedLanguageId");
        }
    }
}
