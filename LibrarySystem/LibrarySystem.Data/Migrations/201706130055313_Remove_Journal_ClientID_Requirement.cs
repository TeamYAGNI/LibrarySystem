namespace LibrarySystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Journal_ClientID_Requirement : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Journals", new[] { "ClientId" });
            AlterColumn("dbo.Journals", "ClientId", c => c.Int());
            CreateIndex("dbo.Journals", "ClientId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Journals", new[] { "ClientId" });
            AlterColumn("dbo.Journals", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Journals", "ClientId");
        }
    }
}
