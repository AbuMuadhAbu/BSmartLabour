namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_HelpDesc1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_HelpDescMaster", "UserType", c => c.String(nullable: false));
            AlterColumn("dbo.TBL_HelpDescMaster", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.TBL_HelpDescMaster", "UserEmail", c => c.String(nullable: false));
            AlterColumn("dbo.TBL_HelpDescMaster", "Usermobile", c => c.String(nullable: false));
            AlterColumn("dbo.TBL_HelpDescMaster", "Issue", c => c.String(nullable: false));
            AlterColumn("dbo.TBL_HelpDescMaster", "Remarks", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TBL_HelpDescMaster", "Remarks", c => c.String());
            AlterColumn("dbo.TBL_HelpDescMaster", "Issue", c => c.String());
            AlterColumn("dbo.TBL_HelpDescMaster", "Usermobile", c => c.String());
            AlterColumn("dbo.TBL_HelpDescMaster", "UserEmail", c => c.String());
            AlterColumn("dbo.TBL_HelpDescMaster", "UserName", c => c.String());
            DropColumn("dbo.TBL_HelpDescMaster", "UserType");
        }
    }
}
