using System;
using System.Collections.Generic;
using YSAPI.Models;

namespace YSAPI.Contexts
{
    interface ISalaryRepository
    {
        IEnumerable<SalaryMaster> GetAll();
        SalaryMaster GetSalaryDetail(Guid employeeId);
        void CreateSalary(SalaryMaster salaryMaster);
        void CreateSalaryTransaction(SalaryTransaction salaryTransaction);
        void EditSalary(SalaryMaster s);
    }
}
