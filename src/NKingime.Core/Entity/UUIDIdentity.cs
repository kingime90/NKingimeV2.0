using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NKingime.Core.Entity
{
    /// <summary>
    /// UUID。
    /// </summary>
    public abstract class UUIDIdentity : IEntity<long>
    {
        /// <summary>
        /// 主键ID。
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }
    }
}
