namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalAmountAndUsersinSponsorWebsite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_SPONSOROTHERDONATION_SMT", "NoofUsers", c => c.Int(nullable: false));
            AddColumn("dbo.TBL_SPONSOROTHERDONATION_SMT", "TotalAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_SPONSOROTHERDONATION_SMT", "TotalAmount");
            DropColumn("dbo.TBL_SPONSOROTHERDONATION_SMT", "NoofUsers");
        }
    }
}
