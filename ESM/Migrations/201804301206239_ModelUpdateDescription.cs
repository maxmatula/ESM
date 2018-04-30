namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdateDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Certyfications", "Description", c => c.String());
            AddColumn("dbo.RecruitmentDocuments", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RecruitmentDocuments", "Description");
            DropColumn("dbo.Certyfications", "Description");
        }
    }
}
