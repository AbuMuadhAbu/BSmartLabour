namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateHiddenMAster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_HiddenSponsorDonateAmount",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_HiddenSponsorDonateAmount");
        }
    }
}
