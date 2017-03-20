namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTokenID : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HelpDeskMaster", "TokenID", c => c.String());
            DropColumn("dbo.TBL_HelpDeskMaster", "ADC");
            DropColumn("dbo.TBL_HelpDeskMaster", "EDC");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TBL_HelpDeskMaster", "EDC", c => c.DateTime());
            AddColumn("dbo.TBL_HelpDeskMaster", "ADC", c => c.DateTime());
            DropColumn("dbo.TBL_HelpDeskMaster", "TokenID");
        }
    }
}
