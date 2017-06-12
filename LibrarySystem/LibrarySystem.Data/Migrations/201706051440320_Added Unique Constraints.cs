// <copyright file = "201706051440320_Added Unique Constraints.cs" company="YAGNI">
// All rights reserved.
// </copyright>

using System.Data.Entity.Migrations;
 
    namespace LibrarySystem.Data.Migrations
{
    /// <summary>
    /// Represent a <see cref="AddedUniqueConstraints"/> class, heir of <see cref="DbMigration"/>.
    /// </summary>
    public partial class AddedUniqueConstraints : DbMigration
    {
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            this.RenameColumn(table: "dbo.Employees", name: "First Name", newName: "FirstName");
            this.RenameColumn(table: "dbo.Employees", name: "Last Name", newName: "LastName");
            this.AddColumn("dbo.Clients", "FirstName", c => c.String(nullable: false, maxLength: 20));
            this.AddColumn("dbo.Clients", "LastName", c => c.String(nullable: false, maxLength: 20));
            this.AddColumn("dbo.Clients", "GenderType", c => c.Int(nullable: false));
            this.AddColumn("dbo.Authors", "FirstName", c => c.String(nullable: false, maxLength: 20));
            this.AddColumn("dbo.Authors", "LastName", c => c.String(nullable: false, maxLength: 20));
            this.AddColumn("dbo.Authors", "GenderType", c => c.Int(nullable: false));
            this.AddColumn("dbo.Employees", "GenderType", c => c.Int(nullable: false));
            this.AlterColumn("dbo.Clients", "PIN", c => c.String(nullable: false, maxLength: 10));
            this.AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false, maxLength: 13));
            this.AlterColumn("dbo.Journals", "ISSN", c => c.String(nullable: false, maxLength: 9));
            this.CreateIndex("dbo.Clients", "PIN", unique: true);
            this.CreateIndex("dbo.Books", "ISBN", unique: true);
            this.CreateIndex("dbo.Genres", "Name", unique: true);
            this.CreateIndex("dbo.Publishers", "Name", unique: true);
            this.CreateIndex("dbo.Journals", "ISSN", unique: true);
            this.CreateIndex("dbo.Subjects", "Name", unique: true);
            this.DropColumn("dbo.Clients", "Name");
            this.DropColumn("dbo.Authors", "Name");
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.AddColumn("dbo.Authors", "Name", c => c.String(nullable: false, maxLength: 50));
            this.AddColumn("dbo.Clients", "Name", c => c.String(nullable: false, maxLength: 50));
            this.DropIndex("dbo.Subjects", new[] { "Name" });
            this.DropIndex("dbo.Journals", new[] { "ISSN" });
            this.DropIndex("dbo.Publishers", new[] { "Name" });
            this.DropIndex("dbo.Genres", new[] { "Name" });
            this.DropIndex("dbo.Books", new[] { "ISBN" });
            this.DropIndex("dbo.Clients", new[] { "PIN" });
            this.AlterColumn("dbo.Journals", "ISSN", c => c.String(nullable: false));
            this.AlterColumn("dbo.Books", "ISBN", c => c.String(nullable: false));
            this.AlterColumn("dbo.Clients", "PIN", c => c.Int(nullable: false));
            this.DropColumn("dbo.Employees", "GenderType");
            this.DropColumn("dbo.Authors", "GenderType");
            this.DropColumn("dbo.Authors", "LastName");
            this.DropColumn("dbo.Authors", "FirstName");
            this.DropColumn("dbo.Clients", "GenderType");
            this.DropColumn("dbo.Clients", "LastName");
            this.DropColumn("dbo.Clients", "FirstName");
            this.RenameColumn(table: "dbo.Employees", name: "LastName", newName: "Last Name");
            this.RenameColumn(table: "dbo.Employees", name: "FirstName", newName: "First Name");
        }
    }
}
