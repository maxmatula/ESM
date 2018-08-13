namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notes5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
