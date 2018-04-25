namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompanyModelUpdateForLogo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "LogoData", c => c.Binary());
            AddColumn("dbo.Companies", "LogoMimeType", c => c.String(maxLength: 50));
            DropColumn("dbo.Companies", "Logo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "Logo", c => c.String());
            DropColumn("dbo.Companies", "LogoMimeType");
            DropColumn("dbo.Companies", "LogoData");
        }
    }
}
