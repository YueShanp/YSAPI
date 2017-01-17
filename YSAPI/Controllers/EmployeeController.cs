using System.Collections.Generic;
using System.Web.Http;
using YSAPI.Contexts;
using YSAPI.Models;

namespace YSAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //GET: /<controller>/Emplyees
        [HttpGet]
        public IEnumerable<Employee> Employees() => _employeeRepository.GetAllEmployee();
    }
}
