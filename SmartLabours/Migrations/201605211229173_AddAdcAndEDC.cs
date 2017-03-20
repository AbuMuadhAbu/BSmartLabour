namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdcAndEDC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HelpDescMaster", "ADC", c => c.DateTime());
            AddColumn("dbo.TBL_HelpDescMaster", "EDC", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_HelpDescMaster", "EDC");
            DropColumn("dbo.TBL_HelpDescMaster", "ADC");
        }
    }
}
