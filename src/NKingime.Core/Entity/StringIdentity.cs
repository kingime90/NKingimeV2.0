using System;
using System.ComponentModel.DataAnnotations;

namespace NKingime.Core.Entity
{
    /// <summary>
    /// 字符串唯一标识数据实体基类。
    /// </summary>
    [Serializable]
    public abstract class StringIdentity : CloneableEntity<string>
    {
        /// <summary>
        /// 主键ID。
        /// </summary>
        [Key]
        public override string Id { get; set; }
    }
}
