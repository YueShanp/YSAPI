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

            _context.SalaryTransactions.Add(salaryTransaction);
            SaveChanges();
        }

        public void EditSalary(SalaryMaster s)
        {
            if (s == null)
            {
                throw new AggregateException(nameof(SalaryTransaction));
            }

            var salary = _context.Salarys.Find(s.Id);

            if (salary == null)
            {
                throw new NotFiniteNumberException($"{nameof(s)}: {s.Id} not found.");
            }

            try
            {
                salary.BasePay = s.BasePay;
                salary.EditUser = s.EditUser;
                salary.Status = s.Status;
                salary.Type = s.Type;
                salary.LaborInsurance = s.LaborInsurance;
                salary.HealthInsurance = s.HealthInsurance;

                _context.Entry(salary.Employee).State = EntityState.Unchanged;

                var r = _context.SaveChanges();
                Console.WriteLine($"{r} rows updated");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CreateSalaryOtherPayType(SalaryOtherPayType salaryOtherPayType)
        {
            if (salaryOtherPayType == null)
            {
                throw new AggregateException(nameof(SalaryTransaction));
            }

            _context.SalaryOtherPayTypes.Add(salaryOtherPayType);
            SaveChanges();
        }

        public SalaryMaster GetSalary(Guid id) => _context.Salarys.Find(id);
    }
}
