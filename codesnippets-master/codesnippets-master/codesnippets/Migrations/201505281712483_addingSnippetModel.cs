namespace codesnippets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingSnippetModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Snippets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Snippets");
        }
    }
}
