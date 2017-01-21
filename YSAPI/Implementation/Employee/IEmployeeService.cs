using System.Collections.Generic;
using YSAPI.Models;

namespace YSAPI.Implementation
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployee();

        string CreateEmplyeeService(Employee employee);
    }
}
