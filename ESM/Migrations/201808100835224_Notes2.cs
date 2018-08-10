namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notes2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "AdditionalInfo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "AdditionalInfo", c => c.String(maxLength: 500));
        }
    }
}
