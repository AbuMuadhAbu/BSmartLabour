namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShowAllOrg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "ShowAllOrg", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "ShowAllOrg");
        }
    }
}
