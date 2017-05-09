using System.Collections.Generic;
using System.Web.Http;
using YSAPI.Implementation;
using YSAPI.Models;

namespace YSAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        private IEmployeeService _employeeService;

        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }

        //GET: /<controller>/Emplyees
        [HttpGet]
        public IEnumerable<Employee> GetAll() => _employeeService.GetAllEmployee();

        [HttpPost]
        public bool Create(Employee e) => _employeeService.CreateEmplyeeService(e);
    }
}
