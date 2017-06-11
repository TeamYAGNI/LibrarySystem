namespace LibrarySystem.Data.Users.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAuthKeyExpirationDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Users", "AuthKeyExpirationDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.Users", "AuthKeyExpirationDate");
        }
    }
}
