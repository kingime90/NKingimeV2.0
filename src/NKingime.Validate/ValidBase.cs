using System;
using System.Reflection;
using System.Linq.Expressions;
using System.Collections.Generic;
using NKingime.Utility.General;

namespace NKingime.Validate
{
    /// <summary>
    /// 实体验证基类。
    /// </summary>
    /// <typeparam name="TEntity">实体接口类型。</typeparam>
    public abstract class ValidBase<TEntity> : IValid<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// 属性类型验证集合。
        /// </summary>
        protected readonly IDictionary<PropertyInfo, ITypeValid> TypeValidSet = new Dictionary<PropertyInfo, ITypeValid>();

        /// <summary>
        /// 初始化一个<see cref="ValidBase{TEntity}"/>类型的新实例。
        /// </summary>
        public ValidBase() : this(new ValidateResource())
        {

        }

        /// <summary>
        /// 初始化一个<see cref="ValidBase{TEntity}"/>类型的新实例。
        /// </summary>
        /// <param name="i18nResource">全球化资源。</param>
        public ValidBase(I18nResourceBase i18nResource)
        {
            I18nResource = i18nResource;
        }

        /// <summary>
        /// 全球化资源。
        /// </summary>
        public I18nResourceBase I18nResource { get; }

        /// <summary>
        /// 字符串类型验证。
        /// </summary>
        /// <param name="propertySelector">选择字符串类型属性函数。</param>
        /// <returns></returns>
        public virtual IStringTypeValid StringType(Expression<Func<TEntity, string>> propertySelector)
        {
            var propertyInfo = (PropertyInfo)(propertySelector.Body as MemberExpression).Member;
            var typeValid = new StringTypeValid(I18nResource);
            AddTypeValid(propertyInfo, typeValid);
            return typeValid;
        }

        /// <summary>
        /// 值类型验证。
        /// </summary>
        /// <typeparam name="TProperty">值类型。</typeparam>
        /// <param name="propertySelector">选择值类型属性函数。</param>
        /// <returns></returns>
        public virtual IValueTypeValid<TProperty> ValueType<TProperty>(Expression<Func<TEntity, TProperty>> propertySelector) where TProperty : struct, IComparable
        {
            var propertyInfo = (PropertyInfo)(propertySelector.Body as MemberExpression).Member;
            var typeValid = new ValueTypeValid<TProperty>(I18nResource);
            AddTypeValid(propertyInfo, typeValid);
            return typeValid;
        }

        /// <summary>
        /// 可空值类型验证。
        /// </summary>
        /// <typeparam name="TProperty">值类型。</typeparam>
        /// <param name="propertySelector">选择可空值类型属性函数。</param>
        /// <returns></returns>
        public virtual INullableTypeValid<TProperty> NullableType<TProperty>(Expression<Func<TEntity, TProperty?>> propertySelector) where TProperty : struct, IComparable
        {
            var propertyInfo = (PropertyInfo)(propertySelector.Body as MemberExpression).Member;
            var typeValid = new NullableTypeValid<TProperty>(I18nResource);
            AddTypeValid(propertyInfo, typeValid);
            return typeValid;
        }

        /// <summary>
        /// 验证实体是否满足规则。
        /// </summary>
        /// <param name="entity">实体实例。</param>
        /// <returns></returns>
        public abstract ValidResult Validate(TEntity entity);

        /// <summary>
        /// 添加类型验证。
        /// </summary>
        /// <param name="propertyInfo">属性信息。</param>
        /// <param name="typeValid">类型验证。</param>
        protected virtual void AddTypeValid(PropertyInfo propertyInfo, ITypeValid typeValid)
        {
            if (TypeValidSet.ContainsKey(propertyInfo))
            {
                TypeValidSet[propertyInfo] = typeValid;
            }
            else
            {
                TypeValidSet.Add(propertyInfo, typeValid);
            }
        }
    }
}
