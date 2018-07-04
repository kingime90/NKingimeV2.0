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
        protected readonly IDictionary<PropertyInfo, IValid> EntityTypeValidSet = new Dictionary<PropertyInfo, IValid>();

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
                EntityTypeValidSet[propertyInfo] = valid;
            }
            else
            {
                EntityTypeValidSet.Add(propertyInfo, valid);
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
            var validResult = base.Validate(entity);
            if (!validResult.Result)
            {
                return validResult;
            }
            //
            object value;
            MethodInfo methodInfo;
            foreach (var item in EntityTypeValidSet)
            {
                methodInfo = item.Value.GetType().GetMethod(nameof(Validate));
                value = item.Key.GetValue(entity);
                validResult = methodInfo.Invoke(item.Value, new object[] { value }) as ValidResult;
                if (!validResult.Result)
                {
                    return validResult;
                }
            }
            return validResult;
        }
    }
}
