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
    }
}
