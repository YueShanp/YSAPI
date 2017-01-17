using System;
using System.Collections.Generic;
using YSAPI.Models;

namespace YSAPI.Contexts
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployee();

        Employee GetEmplyee(Guid employeeId);

        void CreateEmployee(Employee Employee);
    }
}
