namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HelpDeskLog2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TBL_HelpDeskMaster", "UserID", "dbo.Labours");
            DropIndex("dbo.TBL_HelpDeskMaster", new[] { "UserID" });
            AddColumn("dbo.TBL_HelpDeskMaster", "OrgId", c => c.Int(nullable: false));
            AddColumn("dbo.TBL_HelpDeskMaster", "EmiratesID", c => c.String());
            DropColumn("dbo.TBL_HelpDeskMaster", "UserID");
            DropColumn("dbo.TBL_HelpDeskMaster", "LabourID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_HelpDeskMaster", "LabourID", c => c.String());
            AddColumn("dbo.TBL_HelpDeskMaster", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.TBL_HelpDeskMaster", "EmiratesID");
            DropColumn("dbo.TBL_HelpDeskMaster", "OrgId");
            CreateIndex("dbo.TBL_HelpDeskMaster", "UserID");
            AddForeignKey("dbo.TBL_HelpDeskMaster", "UserID", "dbo.Labours", "UserID", cascadeDelete: true);
        }
    }
}
