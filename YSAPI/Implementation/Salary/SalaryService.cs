using System;
using System.Collections.Generic;
using YSAPI.Contexts;
using YSAPI.Models;

namespace YSAPI.Implementation
{
    public class SalaryService : ISalaryService
    {
        private ISalaryRepository _salaryRepository;

        public SalaryService()
        {
            _salaryRepository = new SalaryRepository();
        }

        public bool CreateSalary()
        {
            throw new NotImplementedException();
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