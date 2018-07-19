using System;
using NKingime.Core.Entity;

namespace NKingime.App.Entity
{
    /// <summary>
    /// 用户地址信息
    /// </summary>
    [Serializable]
    public class UserAddress : UUIDIdentity, ICreateTime, ILastUpdateTime
    {
        /// <summary>
        /// 省
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后更新时间（可空）。
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }
    }
}
