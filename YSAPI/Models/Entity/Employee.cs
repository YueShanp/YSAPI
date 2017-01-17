using System;
using System.ComponentModel.DataAnnotations;

namespace YSAPI.Models
{
    public class Employee : BaseEntity<Guid>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [MaxLength(10)]
        [Display(Name = "姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 暱稱
        /// </summary>
        [Display(Name = "暱稱")]
        [MaxLength(20)]
        public string NickName { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        [Required]
        [Display(Name = "生日")]
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// 連絡電話類別 (0: Home, 1: Cell)
        /// </summary>
        [Required]
        [Display(Name = "連絡電話類別")]
        public PhoneType PhoneType { get; set; }

        /// <summary>
        /// 連絡電話
        /// </summary>
        [Required]
        [MaxLength(20)]
        [Display(Name = "連絡電話")]
        public string Phone { get; set; }

        /// <summary>
        /// 連絡電話類別2
        /// </summary>
        [Display(Name = "連絡電話類別2")]
        public PhoneType Phone2Type { get; set; }

        /// <summary>
        /// 連絡電話2
        /// </summary>
        [MaxLength(20)]
        [Display(Name = "連絡電話2")]
        public string Phone2 { get; set; }

        /// <summary>
        /// 住址區碼
        /// </summary>
        [MinLength(3), MaxLength(5)]
        [Display(Name = "住址區碼")]
        public string ZipCode { get; set; }

        /// <summary>
        /// 住址
        /// </summary>
        [MaxLength(50)]
        [Display(Name = "住址")]
        public string Address { get; set; }

        /// <summary>
        /// 電子郵件
        /// </summary>
        [EmailAddress]
        [MaxLength(50)]
        [Display(Name = "電子郵件")]
        public string Email { get; set; }

        /// <summary>
        /// 到職日期
        /// </summary>
        [Required]
        [Display(Name = "到職日期")]
        public DateTime OnBoardDay { get; set; }

        /// <summary>
        /// 狀態 (0: 離職, 1: 正常, 2: Other)
        /// </summary>
        [Display(Name = "狀態")]
        public EmplyeeStatus Status { get; set; }

        /// <summary>
        /// 註記
        /// </summary>
        [MaxLength(2000)]
        [Display(Name = "註記")]
        public string Note { get; set; }
    }
}
