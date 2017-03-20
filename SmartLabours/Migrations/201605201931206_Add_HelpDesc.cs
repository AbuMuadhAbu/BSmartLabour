namespace SmartLabours.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_HelpDesc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_HelpDescMaster",
                c => new
                    {
                        HelpDeskId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserEmail = c.String(),
                        Usermobile = c.String(),
                        organization = c.String(),
                        Issue = c.String(),
                        Remarks = c.String(),
                        IssueStatus = c.String(),
                        CreatedBy = c.String(),
                        ModifiedBy = c.String(),
                        CreatedDate = c.DateTime(),
                        ModifiedDate = c.DateTime(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HelpDeskId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TBL_HelpDescMaster");
        }
    }
}
