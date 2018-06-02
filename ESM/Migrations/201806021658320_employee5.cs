namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Employees", "Surname", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Employees", "Title", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Employees", "IdentityNumber", c => c.String(maxLength: 20));
            AlterColumn("dbo.Employees", "Address", c => c.String(maxLength: 300));
            AlterColumn("dbo.Employees", "Phone", c => c.String(maxLength: 12));
            AlterColumn("dbo.Employees", "MaritalStatus", c => c.String(maxLength: 20));
            AlterColumn("dbo.Employees", "AdditionalInfo", c => c.String(maxLength: 500));
            AlterColumn("dbo.Employees", "BankName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Employees", "BankAccountNumber", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "BankAccountNumber", c => c.String());
            AlterColumn("dbo.Employees", "BankName", c => c.String());
            AlterColumn("dbo.Employees", "AdditionalInfo", c => c.String());
            AlterColumn("dbo.Employees", "MaritalStatus", c => c.String());
            AlterColumn("dbo.Employees", "Phone", c => c.String());
            AlterColumn("dbo.Employees", "Address", c => c.String());
            AlterColumn("dbo.Employees", "IdentityNumber", c => c.Long());
            AlterColumn("dbo.Employees", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
        }
    }
}
