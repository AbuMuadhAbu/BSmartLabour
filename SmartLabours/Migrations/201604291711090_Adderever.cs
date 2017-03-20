namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adderever : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PhoneAsssignedToLabours", "City", c => c.String());
            AddColumn("dbo.PhoneAsssignedToLabours", "State", c => c.String());
            AddColumn("dbo.PhoneAsssignedToLabours", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PhoneAsssignedToLabours", "Country");
            DropColumn("dbo.PhoneAsssignedToLabours", "State");
            DropColumn("dbo.PhoneAsssignedToLabours", "City");
        }
    }
}
