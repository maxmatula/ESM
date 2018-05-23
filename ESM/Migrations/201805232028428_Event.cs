namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Event : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        CompanyId = c.Guid(nullable: false),
                        EmployeeId = c.Guid(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Events", new[] { "CompanyId" });
            DropTable("dbo.Events");
        }
    }
}
