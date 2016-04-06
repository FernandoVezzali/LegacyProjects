namespace codesnippets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class versionDDL : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Snippets", "SelectedLanguageVersionId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Snippets", "SelectedLanguageVersionId");
        }
    }
}
