using System;
using System.ComponentModel;
using NKingime.Utility.General;
using NKingime.Utility.Extensions;

namespace NKingime.Validate
{
    /// <summary>
    /// 简单实体验证。
    /// </summary>
    /// <typeparam name="TEntity">实体接口类型。</typeparam>
    public class SimpleValid<TEntity> : SimpleValidBase<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// 描述特性的类型信息。
        /// </summary>
        private readonly Type _descriptionType = typeof(DescriptionAttribute);

        /// <summary>
        /// 初始化一个<see cref="SimpleValid{TEntity}"/>类型的新实例。
        /// </summary>
        public SimpleValid() : base()
        {

        }

        /// <summary>
        /// 初始化一个<see cref="SimpleValid{TEntity}"/>类型的新实例。
        /// </summary>
        /// <param name="i18nResource">全球化资源。</param>
        public SimpleValid(I18nResourceBase i18nResource) : base(i18nResource)
        {

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
            object propertyValue;
            string description;
            var validResult = new ValidResult();
            foreach (var typeValid in TypeValidSet)
            {
                propertyValue = typeValid.Key.GetValue(entity);
                description = typeValid.Key.GetDescription(_descriptionType).IfNullOrWhiteSpace(typeValid.Key.Name);
                validResult = typeValid.Value.Validate(propertyValue, typeValid.Key.Name, description, entity);
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
