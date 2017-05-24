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
        {
            var salaryList = from salaryMaster in _context.Salarys
                             join employee in _context.Employees on
                             salaryMaster.Employee.Id equals employee.Id
                             select new { salaryMaster, employee };

            var salary = new List<SalaryMaster>();
            foreach (var sList in salaryList)
            {
                var sm = sList.salaryMaster;
                sm.Employee = sList.employee;
                salary.Add(sm);
            }

            return salary;
        }

        public SalaryMaster GetSalaryDetail(Guid employeeId) 
            => _context.Salarys.FirstOrDefault(x => Guid.Equals(x.Employee.Id, employeeId));

        public void CreateSalary(SalaryMaster salaryMaster)
        {
            if (salaryMaster == null)
            {
                throw new ArgumentException(nameof(SalaryMaster));
            }

            _context.Entry(salaryMaster.Employee).State = EntityState.Unchanged;
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
