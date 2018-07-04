using System;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace NKingime.Validate
{
    /// <summary>
    ///  复合实体验证。
    /// </summary>
    /// <typeparam name="TEntity">实体接口类型。</typeparam>
    public class CompoundValid<TEntity> : SimpleValid<TEntity>, ICompoundValid<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// 属性实体类型验证集合。
        /// </summary>
        protected readonly IDictionary<PropertyInfo, IValid<IEntity>> EntityTypeValidSet = new Dictionary<PropertyInfo, IValid<IEntity>>();

        /// <summary>
        /// 实体类型验证。
        /// </summary>
        /// <typeparam name="TProperty">实体类型。</typeparam>
        /// <param name="propertySelector">选择可空值类型属性函数。</param>
        /// <param name="valid">实体验证。</param>
        /// <returns></returns>
        public IEntityTypeValid<TProperty> EntityType<TProperty>(Expression<Func<TEntity, TProperty>> propertySelector, IValid<TProperty> valid) where TProperty : class, IEntity
        {
            var propertyInfo = (PropertyInfo)(propertySelector.Body as MemberExpression).Member;
            var typeValid = new EntityTypeValid<TProperty>(I18nResource);
            AddTypeValid(propertyInfo, typeValid);
            if (EntityTypeValidSet.ContainsKey(propertyInfo))
            {
                EntityTypeValidSet[propertyInfo] = valid as IValid<IEntity>;
            }
            else
            {
                EntityTypeValidSet.Add(propertyInfo, (IValid<IEntity>)valid);
            }
            return typeValid;
        }

        /// <summary>
        /// 验证实体是否满足规则。
        /// </summary>
        /// <param name="entity">实体实例。</param>
        /// <returns></returns>
        public override ValidResult Validate(TEntity entity)
        {
            return base.Validate(entity);
        }
    }
}
