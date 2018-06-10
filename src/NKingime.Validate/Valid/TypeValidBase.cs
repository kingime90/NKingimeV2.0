using System;
using NKingime.Utility.General;

namespace NKingime.Validate
{
    /// <summary>
    /// 类型验证基类。
    /// </summary>
    public abstract class TypeValidBase : ITypeValid
    {
        /// <summary>
        /// 属性名称。
        /// </summary>
        public const string PropertyName = "name";

        /// <summary>
        /// 初始化一个<see cref="TypeValidBase"/>类型的新实例。
        /// </summary>
        public TypeValidBase() : this(new ValidResource())
        {

        }

        /// <summary>
        /// 初始化一个<see cref="TypeValidBase"/>类型的新实例。
        /// </summary>
        /// <param name="i18nResource">全球化资源。</param>
        public TypeValidBase(I18nResourceBase i18nResource)
        {
            I18nResource = i18nResource;
        }

        /// <summary>
        /// 全球化资源。
        /// </summary>
        public I18nResourceBase I18nResource { get; }

        /// <summary>
        /// 验证值是否满足规则。
        /// </summary>
        /// <param name="value">需要验证的值。</param>
        /// <param name="description">需要验证的值的描述。</param>
        /// <param name="root">需要验证的值的根对象，如果没有，则为 null。</param>
        /// <returns></returns>
        public abstract ValidResult Validate(object value, string description, object root = null);
    }
}
