using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using NKingime.Core.Data;
using NKingime.Core.Entity;

namespace NKingime.Entity.Mapper
{
    /// <summary>
    /// 数据实体映射配置基类。
    /// </summary>
    /// <typeparam name="TEntity">数据实体类型。</typeparam>
    /// <typeparam name="TKey">主键类型。</typeparam>
    /// <typeparam name="TDbContext">数据库上下文类型。</typeparam>
    public abstract class EntityMapperBase<TEntity, TKey, TDbContext> : EntityTypeConfiguration<TEntity>, IEntityMapper where TEntity : class, IEntity<TKey> where TDbContext : DbContext, IUnitOfWork, new() where TKey : IEquatable<TKey>
    {
        private readonly Type _dbContextType = typeof(TDbContext);

        /// <summary>
        /// 数据库上下文类型。
        /// </summary>
        public Type DbContextType
        {
            get
            {
                return _dbContextType;
            }
        }

        /// <summary>
        /// 将数据实体映射对象注册到当前数据访问上下文实体映射配置注册器中。
        /// </summary>
        /// <param name="configurations">实体映射配置注册器。</param>
        public void RegistTo(ConfigurationRegistrar configurations)
        {
            KeyMapping();
            PropertyMapping();
            configurations.Add(this);
        }

        /// <summary>
        /// 主键映射。
        /// </summary>
        protected virtual void KeyMapping()
        {
            
        }

        /// <summary>
        /// 属性映射。
        /// </summary>
        protected virtual void PropertyMapping()
        {

        }
    }
}
