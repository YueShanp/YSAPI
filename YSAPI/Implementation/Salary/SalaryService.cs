using System;
using System.Collections.Generic;
using YSAPI.Contexts;
using YSAPI.Models;

namespace YSAPI.Implementation
{
    public class SalaryService : ISalaryService
    {
        private IEmployeeRepository _employeeRepository;
        private ISalaryRepository _salaryRepository;

        public SalaryService()
        {
            _employeeRepository = new EmployeeRepository();
            _salaryRepository = new SalaryRepository();
        }

        public bool CreateSalary(SalaryMaster salaryMaster)
        {
            return CreateSalary(salaryMaster.Employee.Id, salaryMaster);
        }

        public bool CreateSalary(Guid emplyeeId, SalaryMaster salaryMaster)
        {
            // TODO: validation.
            try
            {
                salaryMaster.Employee = _employeeRepository.GetEmplyee(emplyeeId);
                
                salaryMaster.Id = Guid.NewGuid();
                salaryMaster.InDateTime = DateTime.Now;
                salaryMaster.EditDateTime = DateTime.Now;
                _salaryRepository.CreateSalary(salaryMaster);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CreateSalaryTransaction()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalaryMaster> GetAll() => _salaryRepository.GetAll();

        public bool UpdateSalary()
        {
            throw new NotImplementedException();
        }
    }
}