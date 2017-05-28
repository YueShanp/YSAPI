using System;
using System.Collections.Generic;
using System.Web.Http;
using YSAPI.Implementation;
using YSAPI.Models;

namespace YSAPI.Controllers
{
    public class SalaryController : ApiController
    {
        private ISalaryService _salaryService;

        public SalaryController()
        {
            _salaryService = new SalaryService();
        }

        public IEnumerable<SalaryMaster> GetAll() => _salaryService.GetAll();

        public SalaryMaster Get(Guid id) => _salaryService.Get(id);

        [HttpPost]
        public bool Create(SalaryMaster salaryMaster) => _salaryService.CreateSalary(salaryMaster);

        [HttpPost]
        public bool Edit(SalaryMaster s) => _salaryService.EditSalary(s);

        [HttpPost]
        public bool Create(SalaryOtherPayType salaryOtherPayType) => _salaryService.CreateSalaryOtherPayType(salaryOtherPayType);

        [HttpPost]
        public bool CreateMonthTransation() => true;

        [HttpPost]
        public bool EditMonthTransation() => true;
    }
}
