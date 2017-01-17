using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YSAPI.Models
{
    /// <summary>
    /// Base Entity
    /// </summary>
    /// <typeparam name="T">Primary key type.</typeparam>
    public abstract class BaseEntity<T>
    {
        /// <summary>
        /// Primary Identity
        /// </summary>
        [Key]
        public virtual T Id { get; set; }

        /// <summary>
        /// 新增日期時間
        /// </summary>
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public virtual DateTime InDateTime { get; set; }

        /// <summary>
        /// 新增者
        /// </summary>
        [Required]
        public virtual string InUser { get; set; }

        /// <summary>
        /// 更新日期時間
        /// </summary>
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime EditDateTime { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        public virtual string EditUser { get; set; }

        /// <summary>
        /// Model entity enable status.
        /// </summary>
        public EntityStatus EntityStatus { get; set; }
    }
}
