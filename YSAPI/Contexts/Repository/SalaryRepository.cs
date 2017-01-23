using System;
using System.Collections.Generic;
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

        public IEnumerable<SalaryMaster> GetAll()
            => _context.Salarys.ToList();

        public SalaryMaster GetSalaryDetail(Guid employeeId) 
            => _context.Salarys.FirstOrDefault(x => Guid.Equals(x.Emplyee.Id, employeeId));

        public void CreateSalary(SalaryMaster salaryMaster)
        {
            if (salaryMaster == null)
            {
                throw new ArgumentException(nameof(SalaryMaster));
            }

            _context.Entry(salaryMaster.SalaryTransactions).State = EntityState.Unchanged;
            _context.Salarys.Add(salaryMaster);
            SaveChanges();
        }

        public void CreateSalaryTransaction(SalaryTransaction salaryTransaction)
        {
            if (salaryTransaction == null)
            {
                throw new AggregateException(nameof(SalaryTransaction));
            }

            _context.SalaryTransaction.Add(salaryTransaction);
            SaveChanges();
        }        
    }
}
