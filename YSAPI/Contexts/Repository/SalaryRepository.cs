using System;
using System.Data.Entity;
using System.Linq;
using YSAPI.Models;

namespace YSAPI.Contexts
{
    public class SalaryRepository : BaseRepository<YSAPIContext>, ISalaryRepository
    {
        public SalaryRepository()
        {
            _context = new YSAPIContext();
        }

        public SalaryMaster GetSalaryDetail(Guid employeeId)
        {
            return _context.Salarys.FirstOrDefault(x => Guid.Equals(x.Emplyee.Id, employeeId));
        }
        public void CreateSalary(SalaryMaster salaryMaster)
        {
            if (salaryMaster == null)
            {
                throw new ArgumentException(nameof(SalaryMaster));
            }

            _context.Entry(salaryMaster.SalaryTransactions).State = EntityState.Unchanged;
            _context.Salarys.Add(salaryMaster);
            this.SaveChanges();
        }

        public void CreateSalaryTransaction(SalaryTransaction salaryTransaction)
        {
            if (salaryTransaction == null)
            {
                throw new AggregateException(nameof(SalaryTransaction));
            }

            _context.SalaryTransaction.Add(salaryTransaction);
            this.SaveChanges();
        }
    }
}
