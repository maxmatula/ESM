namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteId = c.Guid(nullable: false),
                        Content = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        IsInArchive = c.Boolean(nullable: false),
                        EmployeeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.NoteId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            AddColumn("dbo.Employees", "MoveToArchiveTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Notes", new[] { "EmployeeId" });
            DropColumn("dbo.Employees", "MoveToArchiveTime");
            DropTable("dbo.Notes");
        }
    }
}
