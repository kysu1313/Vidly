namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserPhoneNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "UserPhoneNumber", c => c.String(nullable: false, maxLength: 30));
            AddColumn("dbo.AspNetUsers", "UserPhoneNumber", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserPhoneNumber");
            DropColumn("dbo.Customers", "UserPhoneNumber");
        }
    }
}
