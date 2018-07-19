using System;
using System.ComponentModel;
using NKingime.Core.Entity;
using NKingime.App.Entity.Option;

namespace NKingime.App.Entity
{
    /// <summary>
    /// 用户信息实体。
    /// </summary>
    [Serializable]
    public class User : UUIDIdentity, ICreateTime, ILastUpdateTime
    {
        /// <summary>
        /// 用户名。
        /// </summary>
        [Description("用户名")]
        public string Username { get; set; }

        /// <summary>
        /// 性别类型。
        /// </summary>
        public GenderOption? GenderType { get; set; }

        /// <summary>
        /// 生日。
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///手机号码。
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 电子邮箱。
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 地址信息
        /// </summary>
        public virtual UserAddress Address { get; set; }

        /// <summary>
        /// 注册时间。
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后更新时间（可空）。
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }
    }
}
