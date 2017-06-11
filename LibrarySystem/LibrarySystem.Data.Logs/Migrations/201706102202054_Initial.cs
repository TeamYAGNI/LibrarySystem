// <copyright file="201706102202054_Initial.cs" company="YAGNI">
// All rights reserved.
// </copyright>

using System.Data.Entity.Migrations;

namespace LibrarySystem.Data.Logs.Migrations
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
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(nullable: false, maxLength: 1024),
                        DateTime = c.DateTime(nullable: false),
                        LogTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LogTypes", t => t.LogTypeId)
                .Index(t => t.LogTypeId);
            
            CreateTable(
                "dbo.LogTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "IX_NAME");
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            this.DropForeignKey("dbo.Logs", "LogTypeId", "dbo.LogTypes");
            this.DropIndex("dbo.LogTypes", "IX_NAME");
            this.DropIndex("dbo.Logs", new[] { "LogTypeId" });
            this.DropTable("dbo.LogTypes");
            this.DropTable("dbo.Logs");
        }
    }
}
