using System;
using System.Data.Entity;
using YSAPI.Models;

namespace YSAPI.Contexts
{
    public class YSAPIContext : DbContext
    {
        public YSAPIContext()
            : base("name=YSAPIConnection")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalaryMaster> Salarys { get; set; }
        public DbSet<SalaryTransaction> SalaryTransactions { get; set; }
        public DbSet<SalaryOtherPayTransaction> SalaryOtherPayTransactions { get; set; }
        public DbSet<SalaryOtherPayType> SalaryOtherPayTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ////base.OnModelCreating(modelBuilder);
            
            //// 移除複數資料表命名預設行為
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }
    }
}
