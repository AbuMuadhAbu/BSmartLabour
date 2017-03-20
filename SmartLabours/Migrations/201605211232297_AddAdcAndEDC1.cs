namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdcAndEDC1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TBL_HelpDescMaster", "organization", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TBL_HelpDescMaster", "organization", c => c.String());
        }
    }
}
