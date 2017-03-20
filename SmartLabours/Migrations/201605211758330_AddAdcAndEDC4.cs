namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdcAndEDC4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_HelpDeskMaster",
                c => new
                    {
                        HelpDeskId = c.Long(nullable: false, identity: true),
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
        
        public override void Down()
        {
            DropTable("dbo.TBL_HelpDeskMaster");
        }
    }
}