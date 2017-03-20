namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPinCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhoneAsssignedToLabours", "Pincode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhoneAsssignedToLabours", "Pincode");
        }
    }
}
