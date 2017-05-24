using System;
using System.Collections.Generic;
using System.Linq;
using YSAPI.Models;

namespace YSAPI.Contexts
{
    public class EmployeeRepository : BaseRepository<YSAPIContext>, IEmployeeRepository
    {
        public EmployeeRepository()
        {
            _context = new YSAPIContext();
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmplyee(Guid employeeId)
            => base._context.Employees.FirstOrDefault((Employee x) => Guid.Equals(x.Id, employeeId));

        public void CreateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentException(nameof(employee));
            }

            base._context.Employees.Add(employee);
            SaveChanges();
        }
    }
}
