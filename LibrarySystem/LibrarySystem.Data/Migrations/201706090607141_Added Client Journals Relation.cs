namespace LibrarySystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedClientJournalsRelation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Journals", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Journals", "ClientId");
            AddForeignKey("dbo.Journals", "ClientId", "dbo.Clients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Journals", "ClientId", "dbo.Clients");
            DropIndex("dbo.Journals", new[] { "ClientId" });
            DropColumn("dbo.Journals", "ClientId");
        }
    }
}
