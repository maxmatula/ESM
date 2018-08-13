namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeArchive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IsInArchive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "IsInArchive");
        }
    }
}
