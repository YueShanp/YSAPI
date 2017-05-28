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

        public SalaryMaster Get(Guid id)=> _salaryRepository.GetSalary(id);

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
            }
            catch (Exception ex)
            {
                throw;
            }

            return true;
        }

        public bool CreateSalaryTransaction()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SalaryMaster> GetAll() => _salaryRepository.GetAll();

        public bool EditSalary(SalaryMaster s)
        {
            try
            {
                s.EditDateTime = DateTime.Now;
                _salaryRepository.EditSalary(s);
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }

        public bool CreateSalaryOtherPayType(SalaryOtherPayType salaryOtherPayType)
        {
            try
            {
                salaryOtherPayType.Id = Guid.NewGuid();
                salaryOtherPayType.InDateTime = DateTime.Now;
                salaryOtherPayType.EditDateTime = DateTime.Now;

                _salaryRepository.CreateSalaryOtherPayType(salaryOtherPayType);

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }       
    }
}