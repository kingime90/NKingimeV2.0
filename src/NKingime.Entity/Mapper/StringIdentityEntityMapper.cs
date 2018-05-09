using System;
using NKingime.Core.Entity;
using System.Data.Entity;
using NKingime.Core.Data;

namespace NKingime.Entity.Mapper
{
    /// <summary>
    /// 字符串唯一标识数据实体映射配置基类。
    /// </summary>
    /// <typeparam name="TEntity">数据实体类型。</typeparam>
    public abstract class StringIdentityEntityMapper<TEntity, TDbContext> : EntityMapperBase<TEntity, string, TDbContext> where TEntity : class, IEntity<string> where TDbContext : DbContext, IUnitOfWork, new()
    {
        /// <summary>
        /// 主键映射。
        /// </summary>
        protected override void KeyMapping()
        {
            Property(t => t.Id).IsUnicode(false).HasMaxLength(GetMaxLength(typeof(TEntity)));
        }

        /// <summary>
        /// 获取最大长度。
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        private int? GetMaxLength(Type entityType)
        {
            if (typeof(GuidIdentity).IsAssignableFrom(entityType))
            {
                return 32;
            }
            //
            if (typeof(HexIdentity).IsAssignableFrom(entityType))
            {
                return 16;
            }
            //
            return (int?)null;
        }
    }
}
