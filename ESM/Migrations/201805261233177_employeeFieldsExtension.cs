namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeFieldsExtension : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IdentityNumber", c => c.String());
            AddColumn("dbo.Employees", "Address", c => c.String());
            AddColumn("dbo.Employees", "Phone", c => c.String());
            AddColumn("dbo.Employees", "MaritalStatus", c => c.String());
            AddColumn("dbo.Employees", "AdditionalInfo", c => c.String());
            AddColumn("dbo.Employees", "BankName", c => c.String());
            AddColumn("dbo.Employees", "BankAccountNumber", c => c.String());
            DropColumn("dbo.Employees", "CurrentEarnings");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "CurrentEarnings", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Employees", "BankAccountNumber");
            DropColumn("dbo.Employees", "BankName");
            DropColumn("dbo.Employees", "AdditionalInfo");
            DropColumn("dbo.Employees", "MaritalStatus");
            DropColumn("dbo.Employees", "Phone");
            DropColumn("dbo.Employees", "Address");
            DropColumn("dbo.Employees", "IdentityNumber");
        }
    }
}
