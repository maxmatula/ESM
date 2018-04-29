namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSomeFileFeatures : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agreements", "EndDate", c => c.DateTime());
            DropColumn("dbo.Agreements", "FileName");
            DropColumn("dbo.Agreements", "FileMimeType");
            DropColumn("dbo.Certyfications", "FileName");
            DropColumn("dbo.Certyfications", "FileMimeType");
            DropColumn("dbo.RecruitmentDocuments", "FileName");
            DropColumn("dbo.RecruitmentDocuments", "FileMimeType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecruitmentDocuments", "FileMimeType", c => c.String());
            AddColumn("dbo.RecruitmentDocuments", "FileName", c => c.String());
            AddColumn("dbo.Certyfications", "FileMimeType", c => c.String());
            AddColumn("dbo.Certyfications", "FileName", c => c.String());
            AddColumn("dbo.Agreements", "FileMimeType", c => c.String());
            AddColumn("dbo.Agreements", "FileName", c => c.String());
            AlterColumn("dbo.Agreements", "EndDate", c => c.DateTime(nullable: false));
        }
    }
}
