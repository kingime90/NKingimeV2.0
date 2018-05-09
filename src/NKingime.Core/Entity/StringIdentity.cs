using System;
using System.ComponentModel.DataAnnotations;

namespace NKingime.Core.Entity
{
    /// <summary>
    /// 字符串唯一标识基类。
    /// </summary>
    public abstract class StringIdentity : IEntity<string>
    {
        /// <summary>
        /// 主键ID。
        /// </summary>
        [Key]
        public string Id { get; set; }
    }
}
