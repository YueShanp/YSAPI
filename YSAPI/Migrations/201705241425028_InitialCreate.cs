namespace YSAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 10),
                        NickName = c.String(maxLength: 20),
                        BirthDay = c.DateTime(nullable: false),
                        PhoneType = c.Int(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 20),
                        Phone2Type = c.Int(nullable: false),
                        Phone2 = c.String(maxLength: 20),
                        ZipCode = c.String(maxLength: 5),
                        Address = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        OnBoardDay = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                        Note = c.String(maxLength: 2000),
                        InDateTime = c.DateTime(nullable: false),
                        InUser = c.String(nullable: false, maxLength: 50),
                        EditDateTime = c.DateTime(nullable: false),
                        EditUser = c.String(maxLength: 50),
                        EntityStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SalaryMaster",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                        BasePay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Type = c.Int(nullable: false),
                        InDateTime = c.DateTime(nullable: false),
                        InUser = c.String(nullable: false, maxLength: 50),
                        EditDateTime = c.DateTime(nullable: false),
                        EditUser = c.String(maxLength: 50),
                        EntityStatus = c.Int(nullable: false),
                        Employee_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.Employee_Id)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.SalaryTransaction",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PayYearMonth = c.String(nullable: false, maxLength: 6),
                        PayDay = c.DateTime(nullable: false),
                        BasePay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OverTimePay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(maxLength: 2000),
                        InDateTime = c.DateTime(nullable: false),
                        InUser = c.String(nullable: false, maxLength: 50),
                        EditDateTime = c.DateTime(nullable: false),
                        EditUser = c.String(maxLength: 50),
                        EntityStatus = c.Int(nullable: false),
                        SalaryMaster_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SalaryMaster", t => t.SalaryMaster_Id)
                .Index(t => t.SalaryMaster_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalaryTransaction", "SalaryMaster_Id", "dbo.SalaryMaster");
            DropForeignKey("dbo.SalaryMaster", "Employee_Id", "dbo.Employee");
            DropIndex("dbo.SalaryTransaction", new[] { "SalaryMaster_Id" });
            DropIndex("dbo.SalaryMaster", new[] { "Employee_Id" });
            DropTable("dbo.SalaryTransaction");
            DropTable("dbo.SalaryMaster");
            DropTable("dbo.Employee");
        }
    }
}
