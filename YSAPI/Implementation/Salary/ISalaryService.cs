using System;
using System.Collections.Generic;
using YSAPI.Models;

namespace YSAPI.Implementation
{
    public interface ISalaryService
    {
        IEnumerable<SalaryMaster> GetAll();

        bool CreateSalary(SalaryMaster salaryMaster);

        bool CreateSalary(Guid emplyeeId, SalaryMaster salaryMaster);

        bool CreateSalaryTransaction();

        bool EditSalary(SalaryMaster s);
    }
}
