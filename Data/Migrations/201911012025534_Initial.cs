namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Biography = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookAuthors",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Author_Id = c.Guid(),
                        Book_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Isbn = c.String(),
                        Publisher = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookAuthors", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.BookAuthors", "Author_Id", "dbo.Authors");
            DropIndex("dbo.BookAuthors", new[] { "Book_Id" });
            DropIndex("dbo.BookAuthors", new[] { "Author_Id" });
            DropTable("dbo.Books");
            DropTable("dbo.BookAuthors");
            DropTable("dbo.Authors");
        }
    }
}
