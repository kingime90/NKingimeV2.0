using System;
using NKingime.Entity.Mapper;

namespace NKingime.App.Entity.Mapper
{
    /// <summary>
    /// 用户地址信息实体映射配置。
    /// </summary>
    public class UserAddressMapper : DefaultEntityMapper<UserAddress, long>
    {
        /// <summary>
        /// 属性映射。
        /// </summary>
        protected override void PropertyMapping()
        {
            Property(t => t.Province).IsUnicode(false).HasMaxLength(20);
            Property(t => t.City).IsUnicode(false).HasMaxLength(20);
            Property(t => t.Area).IsUnicode(false).HasMaxLength(20);
            Property(t => t.Address).IsUnicode(false).HasMaxLength(50);
        }
    }
}
