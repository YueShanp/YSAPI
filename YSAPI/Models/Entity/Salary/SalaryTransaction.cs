using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace YSAPI.Models
{
    public class SalaryTransaction : BaseEntity<Guid>
    {
        /// <summary>
        /// 工資單年月
        /// </summary>
        [Required]
        [StringLength(6)]
        [Display(Name = "工資單月")]
        public string PayYearMonth { get; set; }

        /// <summary>
        /// 發薪日
        /// </summary>
        [Required]
        [Display(Name = "發薪日")]
        public DateTime PayDay { get; set; }

        /// <summary>
        /// 基本工資
        /// </summary>
        [Required]
        [Display(Name = "基本工資")]
        public decimal BasePay { get; set; }

        /// <summary>
        /// 加班工資
        /// </summary>
        [Display(Name = "加班工資")]
        public decimal OverTimePay { get; set; }

        /// <summary>
        /// 實發總工資
        /// </summary>
        [Required]
        [Display(Name = "實發總工資")]
        public decimal TotalPay { get; set; }

        /// <summary>
        /// 註記
        /// </summary>
        [MaxLength(2000)]
        [Display(Name = "註記")]
        public string Note { get; set; }

        public virtual SalaryMaster SalaryMaster { get; set; }
    }
}
