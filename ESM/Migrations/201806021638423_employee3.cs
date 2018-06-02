namespace ESM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employee3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "IdentityNumber", c => c.Long());
            AlterColumn("dbo.Employees", "BankAccountNumber", c => c.Long());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "BankAccountNumber", c => c.Int());
            AlterColumn("dbo.Employees", "IdentityNumber", c => c.Int());
        }
    }
}
