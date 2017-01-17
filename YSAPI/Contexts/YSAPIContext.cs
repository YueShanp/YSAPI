using System;
using System.Data.Entity;
using YSAPI.Models;

namespace YSAPI.Contexts
{
    public class YSAPIContext : DbContext
    {
        public YSAPIContext()
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalaryMaster> Salarys { get; set; }
        public DbSet<SalaryTransaction> SalaryTransaction { get; set; }
    }
}
