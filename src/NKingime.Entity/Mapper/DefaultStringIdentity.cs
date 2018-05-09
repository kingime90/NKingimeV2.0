using System;
using NKingime.Core.Entity;
using NKingime.Entity.Data;
using System.Data.Entity;
using NKingime.Core.Data;
using NKingime.Utility.Extensions;

namespace NKingime.Entity.Mapper
{
    /// <summary>
    /// 默认数据库上下文字符串唯一标识数据实体映射配置基类。
    /// </summary>
    /// <typeparam name="TEntity">数据实体类型。</typeparam>
    public abstract class DefaultStringIdentity<TEntity> : StringIdentityEntityMapper<TEntity, DefaultDbContext> where TEntity : class, IEntity<string>
    {

    }
}
