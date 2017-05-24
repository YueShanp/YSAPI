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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual T Id { get; set; }

        /// <summary>
        /// 新增日期時間
        /// </summary>
        ///[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        public virtual DateTime InDateTime { get; set; }

        /// <summary>
        /// 新增者
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual string InUser { get; set; }

        /// <summary>
        /// 更新日期時間
        /// </summary>
        /// //[DatabaseGenerated(DatabaseGeneratedOption.Computed)] 確認預設值到底要怎樣設定
        [Required]        
        public DateTime EditDateTime { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        [MaxLength(50)]
        public virtual string EditUser { get; set; }

        /// <summary>
        /// Model entity enable status.
        /// </summary>
        public EntityStatus EntityStatus { get; set; }
    }
}
