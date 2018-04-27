using System;
using NKingime.Entity.Mapper;

namespace NKingime.App.Entity.Mapper
{
    /// <summary>
    /// 用户信息实体映射配置。
    /// </summary>
    public class UserMapper : DefaultEntityMapper<User, string>
    {
        /// <summary>
        /// 模型映射。
        /// </summary>
        protected override void ModelMapping()
        {
            Property(t => t.Username).HasMaxLength(30);
            Property(t => t.Mobile).HasMaxLength(20);
            Property(t => t.Email).HasMaxLength(50);
        }
    }
}
