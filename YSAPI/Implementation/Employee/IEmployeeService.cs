using System.Collections.Generic;
using YSAPI.Models;

namespace YSAPI.Implementation
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployee();

        bool CreateEmplyeeService(Employee employee);

        bool UpdateEmplyeeService(Employee employee);
    }
}
