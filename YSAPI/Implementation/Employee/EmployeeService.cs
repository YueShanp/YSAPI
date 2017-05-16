using System;
using System.Collections.Generic;
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
            employee.InDateTime = DateTime.Now;
            employee.InUser = "sys";
            employee.EditDateTime = DateTime.Now;
            employee.EditUser = "sys";
            
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

        private bool ValidateEmployee(Employee employee)
        {
            if (employee == null)
            {
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