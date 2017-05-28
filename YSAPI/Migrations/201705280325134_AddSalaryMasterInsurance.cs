namespace YSAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSalaryMasterInsurance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SalaryMaster", "LaborInsurance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.SalaryMaster", "HealthInsurance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SalaryMaster", "HealthInsurance");
            DropColumn("dbo.SalaryMaster", "LaborInsurance");
        }
    }
}
