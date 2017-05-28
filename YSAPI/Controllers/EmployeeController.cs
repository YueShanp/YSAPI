using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
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

        public Employee Get(Guid id) => _employeeService.Get(id);

        [HttpPost]
        public bool Create(Employee e)
        {
            // TODO: fix this 要能夠自動驗證 model 驗證，但是又不要受到 model require 影響
            ////if (!ModelState.IsValid)
            ////{
            ////    var errors = ModelState.Select(x => x.Value.Errors)
            ////              .Where(y => y.Count > 0)
            ////              .ToList(); 

            ////    throw new HttpException((int)HttpStatusCode.BadRequest, "BadRequest");
            ////}

            return _employeeService.CreateEmplyeeService(e);
        }

        [HttpPost]
        public bool Edit(Employee e)
        {
            // TODO: add validation
            return _employeeService.Edit(e);
        }
    }
}
