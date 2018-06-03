using System;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace NKingime.Validate
{
    /// <summary>
    /// 简单验证。
    /// </summary>
    public class SimpleValid<TEntity> where TEntity : class
    {
        /// <summary>
        /// 属性类型验证集合。
        /// </summary>
        private readonly IDictionary<PropertyInfo, ITypeValid> ValidRuleSet = new Dictionary<PropertyInfo, ITypeValid>();

        /// <summary>
        /// 字符串类型验证。
        /// </summary>
        /// <param name="propertySelector">选择字符串类型属性函数。</param>
        /// <returns></returns>
        public IStringTypeValid StringType(Expression<Func<TEntity, string>> propertySelector)
        {
            var propertyInfo = (PropertyInfo)(propertySelector.Body as MemberExpression).Member;
            var typeValid = new StringTypeValid();
            ValidRuleSet.Add(propertyInfo, typeValid);
            return typeValid;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertySelector"></param>
        public void ValueType<TProperty>(Expression<Func<TEntity, TProperty>> propertySelector) where TProperty : struct
        {
            var propertyInfo = (PropertyInfo)(propertySelector.Body as MemberExpression).Member;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertySelector"></param>
        public void ReferenceType<TProperty>(Expression<Func<TEntity, TProperty>> propertySelector) where TProperty : class
        {
            var propertyInfo = (PropertyInfo)(propertySelector.Body as MemberExpression).Member;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ValidResult[] Validate(TEntity entity)
        {

            object value;
            foreach (var item in ValidRuleSet)
            {
                value = item.Key.GetValue(entity);
                item.Value.Validate(value);
            }
            return null;
        }
    }
}
