namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeFieldsExtension2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "IdentityNumber", c => c.Int());
            AlterColumn("dbo.Employees", "BankAccountNumber", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "BankAccountNumber", c => c.String());
            AlterColumn("dbo.Employees", "IdentityNumber", c => c.String());
        }
    }
}
