namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeePictureEdit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "PictureData", c => c.Binary());
            AddColumn("dbo.Employees", "PictureMimeType", c => c.String(maxLength: 50));
            DropColumn("dbo.Employees", "Picture");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Picture", c => c.String());
            DropColumn("dbo.Employees", "PictureMimeType");
            DropColumn("dbo.Employees", "PictureData");
        }
    }
}
