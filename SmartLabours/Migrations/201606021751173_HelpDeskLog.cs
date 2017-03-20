namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HelpDeskLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_HelpDeskMasterLog",
                c => new
                    {
                        LogId = c.Long(nullable: false, identity: true),
                        HelpDeskId = c.Long(nullable: false),
                        Description = c.String(),
                        IssueStatus = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.LogId);
            
            AddColumn("dbo.TBL_HelpDeskMaster", "LabourID", c => c.String());
            AddColumn("dbo.TBL_HelpDeskMaster", "IssueType", c => c.String(nullable: false));
            AddColumn("dbo.TBL_HelpDeskMaster", "IssuePriority", c => c.String(nullable: false));
            AddColumn("dbo.TBL_HelpDeskMaster", "Title", c => c.String());
            AddColumn("dbo.TBL_HelpDeskMaster", "Description", c => c.String(nullable: false));
            AddColumn("dbo.TBL_HelpDeskMaster", "FileName", c => c.String());
            DropColumn("dbo.TBL_HelpDeskMaster", "UserName");
            DropColumn("dbo.TBL_HelpDeskMaster", "UserEmail");
            DropColumn("dbo.TBL_HelpDeskMaster", "Usermobile");
            DropColumn("dbo.TBL_HelpDeskMaster", "UserType");
            DropColumn("dbo.TBL_HelpDeskMaster", "organization");
            DropColumn("dbo.TBL_HelpDeskMaster", "Issue");
            DropColumn("dbo.TBL_HelpDeskMaster", "Remarks");
            DropColumn("dbo.TBL_HelpDeskMaster", "AdminReply");
            DropTable("dbo.Tickets");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        subject = c.String(nullable: false),
                        comment = c.String(nullable: false),
                        priority = c.String(nullable: false),
                        type = c.String(nullable: false),
                        status = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TBL_HelpDeskMaster", "AdminReply", c => c.String());
            AddColumn("dbo.TBL_HelpDeskMaster", "Remarks", c => c.String(nullable: false));
            AddColumn("dbo.TBL_HelpDeskMaster", "Issue", c => c.String(nullable: false));
            AddColumn("dbo.TBL_HelpDeskMaster", "organization", c => c.String(nullable: false));
            AddColumn("dbo.TBL_HelpDeskMaster", "UserType", c => c.String(nullable: false));
            AddColumn("dbo.TBL_HelpDeskMaster", "Usermobile", c => c.String(nullable: false));
            AddColumn("dbo.TBL_HelpDeskMaster", "UserEmail", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.TBL_HelpDeskMaster", "UserName", c => c.String(nullable: false));
            DropColumn("dbo.TBL_HelpDeskMaster", "FileName");
            DropColumn("dbo.TBL_HelpDeskMaster", "Description");
            DropColumn("dbo.TBL_HelpDeskMaster", "Title");
            DropColumn("dbo.TBL_HelpDeskMaster", "IssuePriority");
            DropColumn("dbo.TBL_HelpDeskMaster", "IssueType");
            DropColumn("dbo.TBL_HelpDeskMaster", "LabourID");
            DropTable("dbo.TBL_HelpDeskMasterLog");
        }
    }
}
