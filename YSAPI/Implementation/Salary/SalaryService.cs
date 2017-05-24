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

        public bool CreateSalary(Guid emplyeeId, SalaryMaster salaryMaster)
        {
            // TODO: validation.
            try
            {
                salaryMaster.Emplyee = _employeeRepository.GetEmplyee(emplyeeId);
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