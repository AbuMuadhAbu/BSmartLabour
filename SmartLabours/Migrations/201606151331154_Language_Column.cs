namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Language_Column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Language", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Language");
        }
    }
}
