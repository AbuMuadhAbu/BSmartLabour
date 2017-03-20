namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "AllOrgId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "AllOrgId");
        }
    }
}
