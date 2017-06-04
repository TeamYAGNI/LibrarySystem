// <copyright file="201706042101400_Initial.cs" company="YAGNI">
// All rights reserved.
// </copyright>

using System.Data.Entity.Migrations;

namespace LibrarySystem.Data.Migrations
{
    /// <summary>
    /// Represent a <see cref="Initial"/> class, heir of <see cref="DbMigration"/>.
    /// </summary>
    public partial class Initial : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false, maxLength: 100),
                        StreetNumber = c.Int(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        PIN = c.Int(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.Lendings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        BorrоwDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(),
                        Remarks = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId)
                .ForeignKey("dbo.Clients", t => t.ClientId)
                .Index(t => t.BookId)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        ISBN = c.String(nullable: false),
                        Description = c.String(storeType: "ntext"),
                        PageCount = c.Int(nullable: false),
                        YearOfPublishing = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Available = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publishers", t => t.PublisherId)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        SuperGenreId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.SuperGenreId)
                .Index(t => t.SuperGenreId);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Journals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        ImpactFactor = c.Single(),
                        ISSN = c.String(nullable: false),
                        IssueNumber = c.Int(nullable: false),
                        YearOfPublishing = c.Int(nullable: false),
                        PublisherId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Available = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publishers", t => t.PublisherId)
                .Index(t => t.PublisherId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        SuperSubjectId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SuperSubjectId)
                .Index(t => t.SuperSubjectId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(name: "First Name", nullable: false, maxLength: 20),
                        LastName = c.String(name: "Last Name", nullable: false, maxLength: 20),
                        JobTitle = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        ReportsToId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .ForeignKey("dbo.Employees", t => t.ReportsToId)
                .Index(t => t.AddressId)
                .Index(t => t.ReportsToId);
            
            CreateTable(
                "dbo.AuthorBooks",
                c => new
                    {
                        Author_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Author_Id, t.Book_Id })
                .ForeignKey("dbo.Authors", t => t.Author_Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.GenreBooks",
                c => new
                    {
                        Genre_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Genre_Id, t.Book_Id })
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .ForeignKey("dbo.Books", t => t.Book_Id)
                .Index(t => t.Genre_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.SubjectJournals",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        Journal_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Journal_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .ForeignKey("dbo.Journals", t => t.Journal_Id)
                .Index(t => t.Subject_Id)
                .Index(t => t.Journal_Id);
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("dbo.Employees", "ReportsToId", "dbo.Employees");
            this.DropForeignKey("dbo.Employees", "AddressId", "dbo.Addresses");
            this.DropForeignKey("dbo.Lendings", "ClientId", "dbo.Clients");
            this.DropForeignKey("dbo.Subjects", "SuperSubjectId", "dbo.Subjects");
            this.DropForeignKey("dbo.SubjectJournals", "Journal_Id", "dbo.Journals");
            this.DropForeignKey("dbo.SubjectJournals", "Subject_Id", "dbo.Subjects");
            this.DropForeignKey("dbo.Journals", "PublisherId", "dbo.Publishers");
            this.DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            this.DropForeignKey("dbo.Lendings", "BookId", "dbo.Books");
            this.DropForeignKey("dbo.Genres", "SuperGenreId", "dbo.Genres");
            this.DropForeignKey("dbo.GenreBooks", "Book_Id", "dbo.Books");
            this.DropForeignKey("dbo.GenreBooks", "Genre_Id", "dbo.Genres");
            this.DropForeignKey("dbo.AuthorBooks", "Book_Id", "dbo.Books");
            this.DropForeignKey("dbo.AuthorBooks", "Author_Id", "dbo.Authors");
            this.DropForeignKey("dbo.Clients", "AddressId", "dbo.Addresses");
            this.DropForeignKey("dbo.Addresses", "CityId", "dbo.Cities");
            this.DropIndex("dbo.SubjectJournals", new[] { "Journal_Id" });
            this.DropIndex("dbo.SubjectJournals", new[] { "Subject_Id" });
            this.DropIndex("dbo.GenreBooks", new[] { "Book_Id" });
            this.DropIndex("dbo.GenreBooks", new[] { "Genre_Id" });
            this.DropIndex("dbo.AuthorBooks", new[] { "Book_Id" });
            this.DropIndex("dbo.AuthorBooks", new[] { "Author_Id" });
            this.DropIndex("dbo.Employees", new[] { "ReportsToId" });
            this.DropIndex("dbo.Employees", new[] { "AddressId" });
            this.DropIndex("dbo.Subjects", new[] { "SuperSubjectId" });
            this.DropIndex("dbo.Journals", new[] { "PublisherId" });
            this.DropIndex("dbo.Genres", new[] { "SuperGenreId" });
            this.DropIndex("dbo.Books", new[] { "PublisherId" });
            this.DropIndex("dbo.Lendings", new[] { "ClientId" });
            this.DropIndex("dbo.Lendings", new[] { "BookId" });
            this.DropIndex("dbo.Clients", new[] { "AddressId" });
            this.DropIndex("dbo.Addresses", new[] { "CityId" });
            this.DropTable("dbo.SubjectJournals");
            this.DropTable("dbo.GenreBooks");
            this.DropTable("dbo.AuthorBooks");
            this.DropTable("dbo.Employees");
            this.DropTable("dbo.Subjects");
            this.DropTable("dbo.Journals");
            this.DropTable("dbo.Publishers");
            this.DropTable("dbo.Genres");
            this.DropTable("dbo.Authors");
            this.DropTable("dbo.Books");
            this.DropTable("dbo.Lendings");
            this.DropTable("dbo.Clients");
            this.DropTable("dbo.Cities");
            this.DropTable("dbo.Addresses");
        }
    }
}
