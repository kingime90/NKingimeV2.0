using System;
using System.ComponentModel;
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
        [Description("用户名")]
        public string Username { get; set; }

        /// <summary>
        /// 性别类型。
        /// </summary>
        [Description("性别类型")]
        public GenderOption? GenderType { get; set; }

        /// <summary>
        /// 生日。
        /// </summary>
        [Description("生日")]
        public DateTime? Birthday { get; set; }

        /// <summary>
        ///手机号码。
        /// </summary>
        [Description("手机号码")]
        public string Mobile { get; set; }

        /// <summary>
        /// 电子邮箱。
        /// </summary>
        [Description("电子邮箱")]
        public string Email { get; set; }

        /// <summary>
        /// 注册时间。
        /// </summary>
        [Description("注册时间")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 最后更新时间（可空）。
        /// </summary>
        [Description("最后更新时间")]
        public DateTime? LastUpdateTime { get; set; }
    }
}
