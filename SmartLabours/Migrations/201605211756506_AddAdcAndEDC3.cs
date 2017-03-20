namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdcAndEDC3 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.TBL_HelpDeskMaster");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TBL_HelpDeskMaster",
                c => new
                    {
                        HelpDeskId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        UserEmail = c.String(nullable: false, maxLength: 50),
                        Usermobile = c.String(nullable: false),
                        UserType = c.String(nullable: false),
                        organization = c.String(nullable: false),
                        Issue = c.String(nullable: false),
                        Remarks = c.String(nullable: false),
                        ADC = c.DateTime(),
                        EDC = c.DateTime(),
                        IssueStatus = c.String(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HelpDeskId);
            
        }
    }
}
