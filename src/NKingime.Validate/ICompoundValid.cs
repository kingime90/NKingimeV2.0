using System;
using System.Linq.Expressions;

namespace NKingime.Validate
{
    /// <summary>
    ///  定义复合实体验证接口。
    /// </summary>
    /// <typeparam name="TEntity">实体接口类型。</typeparam>
    public interface ICompoundValid<TEntity> : IValid<TEntity> where TEntity : IEntity
    {
        void EntityType<TProperty>(Expression<Func<TEntity, TProperty>> propertySelector, IValid<TProperty> valid) where TProperty : IEntity;
    }
}
