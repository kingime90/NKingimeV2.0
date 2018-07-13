using System;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections.Generic;
using NKingime.Utility.Extensions;

namespace NKingime.Validate
{
    /// <summary>
    ///  复合实体验证。
    /// </summary>
    /// <typeparam name="TEntity">实体接口类型。</typeparam>
    public class CompoundValid<TEntity> : SimpleValid<TEntity>, ICompoundValid<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// 验证接口集合。
        /// </summary>
        protected readonly IDictionary<PropertyInfo, IValid> ValidSet = new Dictionary<PropertyInfo, IValid>();

        /// <summary>
        /// 实体类型验证。
        /// </summary>
        /// <typeparam name="TProperty">实体类型。</typeparam>
        /// <param name="propertySelector">选择可空值类型属性函数。</param>
        /// <param name="valid">实体验证。</param>
        /// <returns></returns>
        public IEntityTypeValid<TProperty> EntityType<TProperty>(Expression<Func<TEntity, TProperty>> propertySelector, IValid valid) where TProperty : class, IEntity
        {
            var propertyInfo = (PropertyInfo)(propertySelector.Body as MemberExpression).Member;
            var typeValid = new EntityTypeValid<TProperty>(I18nResource);
            AddTypeValid(propertyInfo, typeValid);
            if (ValidSet.ContainsKey(propertyInfo))
            {
                ValidSet[propertyInfo] = valid;
            }
            else
            {
                ValidSet.Add(propertyInfo, valid);
            }
            return typeValid;
        }

        /// <summary>
        /// 验证指定的值是否满足规则。
        /// </summary>
        /// <param name="entity">需要验证的值。</param>
        /// <returns></returns>
        public override ValidResult Validate(object value)
        {
            value.CheckNotNull(() => nameof(value));
            var entity = (TEntity)value;
            var validResult = base.Validate(entity);
            if (!validResult.Result)
            {
                return validResult;
            }
            //
            object propertyValue;
            foreach (var item in ValidSet)
            {
                propertyValue = item.Key.GetValue(entity);
                validResult = item.Value.Validate(propertyValue);
                //
                if (!validResult.Result)
                {
                    return validResult;
                }
            }
            return validResult;
        }
    }
}
