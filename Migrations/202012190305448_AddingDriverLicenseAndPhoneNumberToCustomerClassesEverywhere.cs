namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDriverLicenseAndPhoneNumberToCustomerClassesEverywhere : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DriverLicense", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DriverLicense");
        }
    }
}
