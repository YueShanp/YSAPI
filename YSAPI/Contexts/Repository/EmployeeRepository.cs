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
        {
            var qEmployee = from e in _context.Employees.ToList()
                            where string.Equals(e.Id, employeeId)
                            select e;

            return qEmployee.ToList().FirstOrDefault();
        }

        public void CreateEmployee(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentException(nameof(employee));
            }

            base._context.Employees.Add(employee);
            SaveChanges();
        }

        public void EditEmployee(Employee e)
        {
            if (e == null)
            {
                throw new AggregateException(nameof(e));
            }

            try
            {
                var employee = base._context.Employees.Find(e.Id);
                if (employee == null)
                {
                    throw new Exception($"{nameof(e)}: {e.Id} not found");
                }

                // update entities.
                employee.Address = e.Address;
                employee.BirthDay = e.BirthDay;
                employee.EditDateTime = e.EditDateTime;
                employee.EditUser = e.EditUser;
                employee.Email = e.Email;
                employee.Name = e.Name;
                employee.NickName = e.NickName;
                employee.Note = e.Note;
                employee.OnBoardDay = e.OnBoardDay;
                employee.Phone = e.Phone;
                employee.Phone2 = e.Phone2;
                employee.Phone2Type = e.Phone2Type;
                employee.PhoneType = e.PhoneType;
                employee.Status = e.Status;
                employee.ZipCode = e.ZipCode;

                var rowCount = _context.SaveChanges();
                Console.WriteLine($"{rowCount} data updated.");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
