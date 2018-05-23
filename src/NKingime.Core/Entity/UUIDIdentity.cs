using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NKingime.Core.Entity
{
    /// <summary>
    /// UUID数据实体基类。
    /// </summary>
    [Serializable]
    public abstract class UUIDIdentity : CloneableEntity<long>
    {
        /// <summary>
        /// 主键ID。
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override long Id { get; set; }
    }
}
