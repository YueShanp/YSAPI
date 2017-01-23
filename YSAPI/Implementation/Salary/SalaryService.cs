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

        public IEnumerable<SalaryMaster> GetAll() => _salaryRepository.GetAll();
    }
}