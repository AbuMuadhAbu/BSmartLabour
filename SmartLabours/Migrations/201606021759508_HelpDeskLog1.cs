namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HelpDeskLog1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HelpDeskMaster", "UserID", c => c.Int(nullable: false));
            AddForeignKey("dbo.TBL_HelpDeskMaster", "UserID", "dbo.Labours", "UserID", cascadeDelete: true);
            CreateIndex("dbo.TBL_HelpDeskMaster", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.TBL_HelpDeskMaster", new[] { "UserID" });
            DropForeignKey("dbo.TBL_HelpDeskMaster", "UserID", "dbo.Labours");
            DropColumn("dbo.TBL_HelpDeskMaster", "UserID");
        }
    }
}
