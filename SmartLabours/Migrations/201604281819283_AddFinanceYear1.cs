namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFinanceYear1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_AdminCONTACTUS_SMT", "FinaceYear", c => c.DateTime(nullable: false));
            AddColumn("dbo.TBL_AdminCONTACTUS_SMT", "HostName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_AdminCONTACTUS_SMT", "HostName");
            DropColumn("dbo.TBL_AdminCONTACTUS_SMT", "FinaceYear");
        }
    }
}
