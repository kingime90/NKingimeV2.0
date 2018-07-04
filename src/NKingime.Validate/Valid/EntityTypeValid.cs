using System;
using NKingime.Utility.General;
using NKingime.Utility.Extensions;
using NKingime.Validate.Properties;

namespace NKingime.Validate
{
    /// <summary>
    /// 实体类型验证。
    /// </summary>
    /// <typeparam name="T">实体类型。</typeparam>
    public class EntityTypeValid<T> : TypeValidBase, IEntityTypeValid<T> where T : class
    {
        /// <summary>
        /// 验证规则。
        /// </summary>
        private EntityTypeRule<T> _validRule = new EntityTypeRule<T>();

        /// <summary>
        /// 初始化一个<see cref="EntityTypeValid"/>类型的新实例。
        /// </summary>
        public EntityTypeValid() : base()
        {

        }

        /// <summary>
        /// 初始化一个<see cref="EntityTypeValid"/>类型的新实例。
        /// </summary>
        /// <param name="i18nResource">全球化资源。</param>
        public EntityTypeValid(I18nResourceBase i18nResource) : base(i18nResource)
        {

        }

        /// <summary>
        /// 设置是否必填，默认必填。
        /// </summary>
        /// <param name="isRequired">是否必填。</param>
        /// <returns></returns>
        public IEntityTypeValid<T> Required(bool isRequired = true)
        {
            _validRule.IsRequired = isRequired;
            return this;
        }

        /// <summary>
        /// 验证值是否满足规则。
        /// </summary>
        /// <param name="value">需要验证的值。</param>
        /// <param name="name">需要验证的值的名称。</param>
        /// <param name="description">需要验证的值的描述。</param>
        /// <param name="root">需要验证的值的根对象，如果没有，则为 null。</param>
        /// <returns></returns>
        public override ValidResult Validate(object value, string name, string description, object root = null)
        {
            var validResult = new ValidResult(false, name, description);
            //必填
            var entity = value as T;
            if (_validRule.IsRequired && entity.IsNull())
            {
                validResult.SetMessage(GetI18nString(nameof(Validate_zh_CN.RequiredError), PropertyName, description));
                return validResult;
            }
            return validResult.Reset(true);
        }
    }
}
