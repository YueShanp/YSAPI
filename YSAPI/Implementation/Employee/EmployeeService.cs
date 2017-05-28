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

        public Employee Get(Guid id) => _employeeRepository.GetEmplyee(id);

        public bool CreateEmplyeeService(Employee employee)
        {
            //// TODO 一些自動產生值得部分，看能不能做到 model 定義去
            employee.Id = Guid.NewGuid();
            employee.InDateTime = DateTime.Now;
            employee.EditDateTime = DateTime.Now;

            try
            {
                _employeeRepository.CreateEmployee(employee);

                return true;
            }
            catch (ArgumentException ex)
            {
                // TODO: write log ex
                return false;
            }
        }

        public bool Edit(Employee e)
        {
            e.EditDateTime = DateTime.Now;

            try
            {
                _employeeRepository.EditEmployee(e);

                return true;
            }
            catch (Exception)
            {
                // TODO: error actions.
                return false;
            }
        }       
    }
}