using System;
using System.Linq.Expressions;

namespace NKingime.Validate
{
    /// <summary>
    ///  定义复合实体验证接口。
    /// </summary>
    /// <typeparam name="TEntity">实体接口类型。</typeparam>
    public interface ICompoundValid<TEntity> : IValid<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// 实体类型验证。
        /// </summary>
        /// <typeparam name="TProperty">实体类型。</typeparam>
        /// <param name="propertySelector">选择可空值类型属性函数。</param>
        /// <param name="valid">实体验证。</param>
        /// <returns></returns>
        IEntityTypeValid<TProperty> EntityType<TProperty>(Expression<Func<TEntity, TProperty>> propertySelector, IValid<TProperty> valid) where TProperty : class, IEntity;
    }
}
