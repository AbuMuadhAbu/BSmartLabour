namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HelpDeskLog3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HelpDeskMaster", "UserType", c => c.String());
            DropColumn("dbo.TBL_HelpDeskMaster", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_HelpDeskMaster", "Title", c => c.String());
            DropColumn("dbo.TBL_HelpDeskMaster", "UserType");
        }
    }
}
