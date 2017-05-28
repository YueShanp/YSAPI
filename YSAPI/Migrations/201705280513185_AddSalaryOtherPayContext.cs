namespace YSAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSalaryOtherPayContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SalaryOtherPayTransaction",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InDateTime = c.DateTime(nullable: false),
                        InUser = c.String(nullable: false, maxLength: 50),
                        EditDateTime = c.DateTime(nullable: false),
                        EditUser = c.String(maxLength: 50),
                        EntityStatus = c.Int(nullable: false),
                        SalaryOtherPayType_Id = c.Guid(),
                        SalaryTransaction_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SalaryOtherPayType", t => t.SalaryOtherPayType_Id)
                .ForeignKey("dbo.SalaryTransaction", t => t.SalaryTransaction_Id)
                .Index(t => t.SalaryOtherPayType_Id)
                .Index(t => t.SalaryTransaction_Id);
            
            CreateTable(
                "dbo.SalaryOtherPayType",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OtherPayName = c.String(),
                        InDateTime = c.DateTime(nullable: false),
                        InUser = c.String(nullable: false, maxLength: 50),
                        EditDateTime = c.DateTime(nullable: false),
                        EditUser = c.String(maxLength: 50),
                        EntityStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalaryOtherPayTransaction", "SalaryTransaction_Id", "dbo.SalaryTransaction");
            DropForeignKey("dbo.SalaryOtherPayTransaction", "SalaryOtherPayType_Id", "dbo.SalaryOtherPayType");
            DropIndex("dbo.SalaryOtherPayTransaction", new[] { "SalaryTransaction_Id" });
            DropIndex("dbo.SalaryOtherPayTransaction", new[] { "SalaryOtherPayType_Id" });
            DropTable("dbo.SalaryOtherPayType");
            DropTable("dbo.SalaryOtherPayTransaction");
        }
    }
}
