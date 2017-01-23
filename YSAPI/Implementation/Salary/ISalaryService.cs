using System.Collections.Generic;
using YSAPI.Models;

namespace YSAPI.Implementation
{
    public interface ISalaryService
    {
        IEnumerable<SalaryMaster> GetAll();
    }
}
