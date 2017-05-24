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

        public bool CreateEmplyeeService(Employee employee)
        {
            //// TODO 一些自動產生值得部分，看能不能做到 model 定義去
            employee.Id = Guid.NewGuid();
            employee.InDateTime = DateTime.Now;
            employee.EditDateTime = DateTime.Now;
            
            try
            {
                _employeeRepository.CreateEmployee(employee);
            }
            catch (ArgumentException ex)
            {
                // TODO: write log ex
                return false;
            }

            return true;
        }       

        public bool UpdateEmplyeeService(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}