namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agreements",
                c => new
                    {
                        AgreementId = c.Guid(nullable: false),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        AddDate = c.DateTime(nullable: false),
                        FileName = c.String(),
                        FileMimeType = c.String(),
                        FilePath = c.String(),
                        EmployeeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.AgreementId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Guid(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        BirthDate = c.String(),
                        Title = c.String(),
                        PictureData = c.Binary(),
                        PictureMimeType = c.String(maxLength: 50),
                        CompanyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Certyfications",
                c => new
                    {
                        CertyficationId = c.Guid(nullable: false),
                        FileName = c.String(),
                        FileMimeType = c.String(),
                        FilePath = c.String(),
                        AddDate = c.DateTime(nullable: false),
                        EmployeeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.CertyficationId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 128),
                        LogoData = c.Binary(),
                        LogoMimeType = c.String(maxLength: 50),
                        Description = c.String(),
                        TotalEarnings = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.UserCompanyRefs",
                c => new
                    {
                        RefId = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 128),
                        CompanyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.RefId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        Title = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        AvatarPath = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Earnings",
                c => new
                    {
                        EarningId = c.Guid(nullable: false),
                        Ammount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AddDate = c.DateTime(nullable: false),
                        EmployeeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EarningId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.RecruitmentDocuments",
                c => new
                    {
                        DocumentId = c.Guid(nullable: false),
                        FileName = c.String(),
                        FileMimeType = c.String(),
                        FilePath = c.String(),
                        AddDate = c.DateTime(nullable: false),
                        EmployeeId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Agreements", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.RecruitmentDocuments", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Earnings", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.UserCompanyRefs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserCompanyRefs", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Certyfications", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RecruitmentDocuments", new[] { "EmployeeId" });
            DropIndex("dbo.Earnings", new[] { "EmployeeId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.UserCompanyRefs", new[] { "CompanyId" });
            DropIndex("dbo.UserCompanyRefs", new[] { "UserId" });
            DropIndex("dbo.Certyfications", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "CompanyId" });
            DropIndex("dbo.Agreements", new[] { "EmployeeId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RecruitmentDocuments");
            DropTable("dbo.Earnings");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.UserCompanyRefs");
            DropTable("dbo.Companies");
            DropTable("dbo.Certyfications");
            DropTable("dbo.Employees");
            DropTable("dbo.Agreements");
        }
    }
}
