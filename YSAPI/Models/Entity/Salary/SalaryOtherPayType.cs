using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YSAPI.Models
{
    public class SalaryOtherPayType : BaseEntity<Guid>
    {
        public string OtherPayName { get; set; }

        public virtual SalaryOtherPayTransaction SalaryOtherPayTransaction { get; set; }
    }
}