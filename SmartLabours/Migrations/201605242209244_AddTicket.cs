namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTicket : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "comment", c => c.String(nullable: false));
            AddColumn("dbo.Tickets", "CreatedDate", c => c.DateTime());
            AddColumn("dbo.Tickets", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.Tickets", "subject", c => c.String(nullable: false));
            AlterColumn("dbo.Tickets", "priority", c => c.String(nullable: false));
            AlterColumn("dbo.Tickets", "type", c => c.String(nullable: false));
            AlterColumn("dbo.Tickets", "status", c => c.String(nullable: false));
            DropColumn("dbo.Tickets", "comment_value");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "comment_value", c => c.String());
            AlterColumn("dbo.Tickets", "status", c => c.String());
            AlterColumn("dbo.Tickets", "type", c => c.String());
            AlterColumn("dbo.Tickets", "priority", c => c.String());
            AlterColumn("dbo.Tickets", "subject", c => c.String());
            DropColumn("dbo.Tickets", "ModifiedDate");
            DropColumn("dbo.Tickets", "CreatedDate");
            DropColumn("dbo.Tickets", "comment");
        }
    }
}
