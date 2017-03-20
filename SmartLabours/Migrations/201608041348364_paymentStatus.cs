namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_SPONSOROTHERDONATION_SMT", "PaymentStatus", c => c.String());
            AddColumn("dbo.TBL_SPONSOROTHERDONATION_SMT", "p_id", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_SPONSOROTHERDONATION_SMT", "p_id");
            DropColumn("dbo.TBL_SPONSOROTHERDONATION_SMT", "PaymentStatus");
        }
    }
}
