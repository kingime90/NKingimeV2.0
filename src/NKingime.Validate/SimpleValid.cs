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
    public class SimpleValid<TEntity> : ValidBase<TEntity> where TEntity : IEntity
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
        /// 验证实体是否满足规则。
        /// </summary>
        /// <param name="entity">实体实例。</param>
        /// <returns></returns>
        public override ValidResult Validate(TEntity entity)
        {
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
            validResult.SetResult(true);
            return validResult;
        }
    }
}
