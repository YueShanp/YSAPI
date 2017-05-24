using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YSAPI.Models
{
    public class SalaryMaster : BaseEntity<Guid>
    {
        /// <summary>
        /// 狀態 (0: No use, 1: Normal)
        /// </summary>
        [Display(Name = "狀態")]
        public SalaryStatus Status { get; set; }

        /// <summary>
        /// 基本薪資
        /// </summary>
        [Display(Name = "基本薪資")]
        public decimal BasePay { get; set; }

        /// <summary>
        /// 薪資類別 (0: 計時, 1: 正職)
        /// </summary>
        [Display(Name = "薪資類別")]
        public SalaryType Type { get; set; }

        public virtual Employee Emplyee { get; set; }
    }
}
