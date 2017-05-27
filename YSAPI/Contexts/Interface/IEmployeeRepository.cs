using System;
using System.Collections.Generic;
using YSAPI.Models;

namespace YSAPI.Contexts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployee();

        Employee GetEmplyee(Guid employeeId);

        void CreateEmployee(Employee Employee);
        void EditEmployee(Employee e);
    }
}
