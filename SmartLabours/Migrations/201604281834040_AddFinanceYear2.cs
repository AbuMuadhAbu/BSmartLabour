namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFinanceYear2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TBL_AdminCONTACTUS_SMT", "FinaceYear", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TBL_AdminCONTACTUS_SMT", "FinaceYear", c => c.DateTime(nullable: false));
        }
    }
}
