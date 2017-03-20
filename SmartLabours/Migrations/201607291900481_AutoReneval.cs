namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutoReneval : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_SPONSOROTHERDONATION_SMT", "AutoReneval", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_SPONSOROTHERDONATION_SMT", "AutoReneval");
        }
    }
}
