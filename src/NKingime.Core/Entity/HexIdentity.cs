using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Core.Entity
{
    /// <summary>
    /// 十六进制标识数据实体基类。
    /// </summary>
    public abstract class HexIdentity : IEntity<string>
    {
        /// <summary>
        /// 主键ID（Guid）。
        /// </summary>
        [Key]
        public string Id { get; set; }
    }
}
