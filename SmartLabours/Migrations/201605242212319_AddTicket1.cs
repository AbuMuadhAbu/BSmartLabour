namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicket1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "status", c => c.String(nullable: false));
        }
    }
}
