using System;
using NKingime.Core.Dto;
using NKingime.Core.Entity;
using NKingime.App.Entity.Option;

namespace NKingime.App.EntityDto
{
    /// <summary>
    /// 用户保存实体DTO。
    /// </summary>
    public class UserSaveDto : UUIDIdentity, IEntityDto
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
    }
}
