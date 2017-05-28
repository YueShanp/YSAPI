namespace YSAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSalaryMasterOddPay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalaryTransaction", "SubTotalPay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.SalaryTransaction", "ToNextMonthOddPay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.SalaryTransaction", "FromLastMonthOddPay", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalaryTransaction", "FromLastMonthOddPay");
            DropColumn("dbo.SalaryTransaction", "ToNextMonthOddPay");
            DropColumn("dbo.SalaryTransaction", "SubTotalPay");
        }
    }
}
