using System;

namespace YSAPI.Models
{
    public class SalaryOtherPayTransaction : BaseEntity<Guid>
    {
        public SalaryOtherPayType SalaryOtherPayType { get; set; }

        public decimal Amount { get; set; }

        public virtual SalaryTransaction SalaryTransaction { get; set; }
    }
}