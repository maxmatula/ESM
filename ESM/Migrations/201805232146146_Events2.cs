namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Events2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Events", "EmployeeId");
            AddForeignKey("dbo.Events", "EmployeeId", "dbo.Employees", "EmployeeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Events", new[] { "EmployeeId" });
        }
    }
}
