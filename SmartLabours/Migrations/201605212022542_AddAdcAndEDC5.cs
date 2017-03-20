namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdcAndEDC5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HelpDeskMaster", "AdminReply", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_HelpDeskMaster", "AdminReply");
        }
    }
}
