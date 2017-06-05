namespace LibrarySystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUniqueConstraints : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Employees", name: "First Name", newName: "FirstName");
            RenameColumn(table: "dbo.Employees", name: "Last Name", newName: "LastName");
            AddColumn("dbo.Clients", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Clients", "LastName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Clients", "GenderType", c => c.Int(nullable: false));
            AddColumn("dbo.Authors", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Authors", "LastName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Authors", "GenderType", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "GenderType", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "PIN", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false, maxLength: 13));
            AlterColumn("dbo.Journals", "ISSN", c => c.String(nullable: false, maxLength: 9));
            CreateIndex("dbo.Clients", "PIN", unique: true);
            CreateIndex("dbo.Books", "ISBN", unique: true);
            CreateIndex("dbo.Genres", "Name", unique: true);
            CreateIndex("dbo.Publishers", "Name", unique: true);
            CreateIndex("dbo.Journals", "ISSN", unique: true);
            CreateIndex("dbo.Subjects", "Name", unique: true);
            DropColumn("dbo.Clients", "Name");
            DropColumn("dbo.Authors", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Authors", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Clients", "Name", c => c.String(nullable: false, maxLength: 50));
            DropIndex("dbo.Subjects", new[] { "Name" });
            DropIndex("dbo.Journals", new[] { "ISSN" });
            DropIndex("dbo.Publishers", new[] { "Name" });
            DropIndex("dbo.Genres", new[] { "Name" });
            DropIndex("dbo.Books", new[] { "ISBN" });
            DropIndex("dbo.Clients", new[] { "PIN" });
            AlterColumn("dbo.Journals", "ISSN", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "PIN", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "GenderType");
            DropColumn("dbo.Authors", "GenderType");
            DropColumn("dbo.Authors", "LastName");
            DropColumn("dbo.Authors", "FirstName");
            DropColumn("dbo.Clients", "GenderType");
            DropColumn("dbo.Clients", "LastName");
            DropColumn("dbo.Clients", "FirstName");
            RenameColumn(table: "dbo.Employees", name: "LastName", newName: "Last Name");
            RenameColumn(table: "dbo.Employees", name: "FirstName", newName: "First Name");
        }
    }
}
