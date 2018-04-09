namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class powrotdobase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.File", "User_Id", "dbo.User");
            DropIndex("dbo.File", new[] { "User_Id" });
            AddColumn("dbo.User", "AvatarPath", c => c.String());
            AlterColumn("dbo.User", "Name", c => c.String());
            AlterColumn("dbo.User", "Surname", c => c.String());
            DropColumn("dbo.User", "AvatarImage");
            DropTable("dbo.File");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.File",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        User_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.FileId);
            
            AddColumn("dbo.User", "AvatarImage", c => c.Binary());
            AlterColumn("dbo.User", "Surname", c => c.String(nullable: false, maxLength: 32));
            AlterColumn("dbo.User", "Name", c => c.String(nullable: false, maxLength: 32));
            DropColumn("dbo.User", "AvatarPath");
            CreateIndex("dbo.File", "User_Id");
            AddForeignKey("dbo.File", "User_Id", "dbo.User", "Id");
        }
    }
}
