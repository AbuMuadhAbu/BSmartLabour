namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PayTabDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tbl_PayTabDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        merchant_email = c.String(),
                        secret_key = c.String(),
                        currency = c.String(),
                        site_url = c.String(),
                        title = c.String(),
                        country = c.String(),
                        country_shipping = c.String(),
                        cms_with_version = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tbl_PayTabDetails");
        }
    }
}
