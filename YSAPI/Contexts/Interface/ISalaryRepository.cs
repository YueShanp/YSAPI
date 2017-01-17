using System;
using YSAPI.Models;

namespace YSAPI.Contexts
{
    interface ISalaryRepository
    {
        SalaryMaster GetSalaryDetail(Guid employeeId);
        void CreateSalary(SalaryMaster salaryMaster);
        void CreateSalaryTransaction(SalaryTransaction salaryTransaction);
    }
}
