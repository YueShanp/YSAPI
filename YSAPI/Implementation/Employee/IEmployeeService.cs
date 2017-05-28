using System;
using System.Collections.Generic;
using YSAPI.Models;

namespace YSAPI.Implementation
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployee();

        bool CreateEmplyeeService(Employee employee);

        bool Edit(Employee e);

        Employee Get(Guid id);
    }
}
