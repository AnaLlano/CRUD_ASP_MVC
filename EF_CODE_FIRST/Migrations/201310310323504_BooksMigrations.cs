namespace EF_CODE_FIRST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BooksMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 30),
                        Author = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Review = c.String(nullable: false),
                        User = c.String(nullable: false, maxLength: 35),
                        BooksId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BooksId, cascadeDelete: true)
                .Index(t => t.BooksId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Reviews", new[] { "BooksId" });
            DropForeignKey("dbo.Reviews", "BooksId", "dbo.Books");
            DropTable("dbo.Reviews");
            DropTable("dbo.Books");
        }
    }
}
