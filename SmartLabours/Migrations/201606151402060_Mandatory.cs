namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mandatory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Language", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Language", c => c.String());
        }
    }
}
