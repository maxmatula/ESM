namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeFieldsExtension3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Title", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Title", c => c.String());
            AlterColumn("dbo.Employees", "Surname", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
        }
    }
}
