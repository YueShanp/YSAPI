using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using YSAPI.Contexts;
using YSAPI.Models;

namespace YSAPI.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public IEnumerable<Employee> GetAllEmployee() => _employeeRepository.GetAllEmployee();

        public string CreateEmplyeeService(Employee employee)
        {
            if (!ValidateEmployee(employee))
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "BadRequest");
            }

            try
            {
                _employeeRepository.CreateEmployee(employee);
            }
            catch (ArgumentException ex)
            {
                return ex.ToString();
            }

            return "Ok";
        }

        private bool ValidateEmployee(Employee employee)
        {
            if (employee == null)
            {
                return false;
            }

            return true;
        }
    }
}