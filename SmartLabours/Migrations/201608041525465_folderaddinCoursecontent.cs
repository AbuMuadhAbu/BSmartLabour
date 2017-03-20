namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class folderaddinCoursecontent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_CourseContentsMaster", "FolderName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_CourseContentsMaster", "FolderName");
        }
    }
}
