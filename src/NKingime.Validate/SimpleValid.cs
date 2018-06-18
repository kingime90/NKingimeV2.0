using System;
using System.Reflection;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Collections.Generic;
using NKingime.Utility.General;
using NKingime.Utility.Extensions;

namespace NKingime.Validate
{
    /// <summary>
    /// 简单验证。
    /// </summary>
    public class SimpleValid<TEntity> where TEntity : class
    {
        /// <summary>
        /// 描述特性类型信息。
        /// </summary>
        private Type _descriptionType;

        /// <summary>
        /// 属性类型验证集合。
        /// </summary>
        private readonly IDictionary<PropertyInfo, ITypeValid> TypeValidSet = new Dictionary<PropertyInfo, ITypeValid>();

        /// <summary>
        /// 初始化一个<see cref="SimpleValid{TEntity}"/>类型的新实例。
        /// </summary>
        public SimpleValid() : this(new ValidResource())
        {

        }

        /// <summary>
        /// 初始化一个<see cref="SimpleValid{TEntity}"/>类型的新实例。
        /// </summary>
        /// <param name="i18nResource">全球化资源。</param>
        public SimpleValid(I18nResourceBase i18nResource)
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
        public IStringTypeValid StringType(Expression<Func<TEntity, string>> propertySelector)
        {
            var propertyInfo = (PropertyInfo)(propertySelector.Body as MemberExpression).Member;
            var typeValid = new StringTypeValid(I18nResource);
            AddTypeValid(propertyInfo, typeValid);
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
        /// 验证实体是否满足规则。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ValidResult Validate(TEntity entity)
        {
            if (_descriptionType == null)
            {
                _descriptionType = typeof(DescriptionAttribute);
            }
            //
            object value;
            string description;
            var validResult = new ValidResult();
            foreach (var typeValid in TypeValidSet)
            {
                value = typeValid.Key.GetValue(entity);
                description = typeValid.Key.GetDescription(_descriptionType).IfNullOrWhiteSpace(typeValid.Key.Name);
                validResult = typeValid.Value.Validate(value, typeValid.Key.Name, description, entity);
                //
                if (!validResult.Result)
                {
                    return validResult;
                }
            }
            return validResult.Reset(true);
        }

        /// <summary>
        /// 添加类型验证。
        /// </summary>
        /// <param name="propertyInfo">属性信息。</param>
        /// <param name="typeValid">类型验证。</param>
        protected void AddTypeValid(PropertyInfo propertyInfo, ITypeValid typeValid)
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
