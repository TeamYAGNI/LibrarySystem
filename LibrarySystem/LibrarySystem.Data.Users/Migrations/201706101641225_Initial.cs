// <copyright file="201706101641225_Initial.cs" company="YAGNI">
// All rights reserved.
// </copyright>

namespace LibrarySystem.Data.Users.Migrations
{
    using System.Data.Entity.Migrations;

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
                "public.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_NAME");
            
            CreateTable(
                "public.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        PassHash = c.String(nullable: false),
                        AuthKey = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true, name: "IX_USERNAME");
            
            CreateTable(
                "public.UserGroups",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Group_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Group_Id })
                .ForeignKey("public.Users", t => t.User_Id)
                .ForeignKey("public.Groups", t => t.Group_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Group_Id);
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("public.UserGroups", "Group_Id", "public.Groups");
            this.DropForeignKey("public.UserGroups", "User_Id", "public.Users");
            this.DropIndex("public.UserGroups", new[] { "Group_Id" });
            this.DropIndex("public.UserGroups", new[] { "User_Id" });
            this.DropIndex("public.Users", "IX_USERNAME");
            this.DropIndex("public.Groups", "IX_NAME");
            this.DropTable("public.UserGroups");
            this.DropTable("public.Users");
            this.DropTable("public.Groups");
        }
    }
}
