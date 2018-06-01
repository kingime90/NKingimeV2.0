using System;
using NKingime.Validate.Tests.Option;

namespace NKingime.Validate.Tests.Entity
{
    /// <summary>
    /// 用户信息实体。
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户名。
        /// </summary>
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
        /// 注册时间。
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后更新时间（可空）。
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }
    }
}
