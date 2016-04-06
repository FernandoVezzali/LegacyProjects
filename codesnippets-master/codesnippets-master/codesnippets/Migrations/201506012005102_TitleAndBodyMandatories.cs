namespace codesnippets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TitleAndBodyMandatories : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Snippets", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Snippets", "Body", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Snippets", "Body", c => c.String());
            AlterColumn("dbo.Snippets", "Title", c => c.String());
        }
    }
}
