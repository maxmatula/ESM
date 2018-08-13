namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notes3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "MoveToArchiveTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "MoveToArchiveTime", c => c.DateTime(nullable: false));
        }
    }
}
