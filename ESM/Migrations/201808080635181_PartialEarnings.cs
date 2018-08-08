namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PartialEarnings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PartialEarnings",
                c => new
                    {
                        PartialEarningId = c.Guid(nullable: false),
                        Name = c.String(),
                        Ammount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EarningId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PartialEarningId)
                .ForeignKey("dbo.Earnings", t => t.EarningId, cascadeDelete: true)
                .Index(t => t.EarningId);
            
            AddColumn("dbo.Agreements", "EarningId", c => c.Guid());
            AddColumn("dbo.Earnings", "ChangeDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Earnings", "AgreementId", c => c.Guid());
            DropColumn("dbo.Earnings", "Ammount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Earnings", "Ammount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.PartialEarnings", "EarningId", "dbo.Earnings");
            DropIndex("dbo.PartialEarnings", new[] { "EarningId" });
            DropColumn("dbo.Earnings", "AgreementId");
            DropColumn("dbo.Earnings", "ChangeDate");
            DropColumn("dbo.Agreements", "EarningId");
            DropTable("dbo.PartialEarnings");
        }
    }
}
