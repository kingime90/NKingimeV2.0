using System;
using NKingime.Utility;
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
        /// 最小值名称。
        /// </summary>
        public const string MinValueName = "minValue";

        /// <summary>
        /// 最大值名称。
        /// </summary>
        public const string MaxValueName = "maxValue";

        /// <summary>
        /// 初始化一个<see cref="TypeValidBase"/>类型的新实例。
        /// </summary>
        public TypeValidBase() : this(new ValidateResource())
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
        /// 获取 全球化资源。
        /// </summary>
        public I18nResourceBase I18nResource { get; }

        /// <summary>
        /// 验证值是否满足规则。
        /// </summary>
        /// <param name="value">需要验证的值。</param>
        /// <param name="name">需要验证的值的名称。</param>
        /// <param name="description">需要验证的值的描述。</param>
        /// <param name="root">需要验证的值的根对象，如果没有，则为 null。</param>
        /// <returns></returns>
        public abstract ValidResult Validate(object value, string name, string description, object root = null);

        /// <summary>
        /// 获取字符串模板内容。
        /// </summary>
        /// <typeparam name="T">值类型。</typeparam>
        /// <param name="template">字符串模板。</param>
        /// <param name="name">参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <returns></returns>
        protected virtual string GetString<T>(string template, string name, T value)
        {
            return STUtil.GetString(template, name, value);
        }

        /// <summary>
        /// 获取字符串模板内容。
        /// </summary>
        /// <typeparam name="T">值类型。</typeparam>
        /// <param name="template">字符串模板。</param>
        /// <param name="parameters">属性数组。</param>
        /// <returns></returns>
        protected virtual string GetString<T>(string template, params STAttribute<T>[] attributes)
        {
            return STUtil.GetString(template, attributes);
        }

        /// <summary>
        /// 获取全球化资源字符串。
        /// </summary>
        /// <typeparam name="T">值类型。</typeparam>
        /// <param name="templateName">模板名称。</param>
        /// <param name="name">参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <returns></returns>
        protected virtual string GetI18nString<T>(string templateName, string name, T value)
        {
            return GetString(I18nResource.GetString(templateName), name, value);
        }

        /// <summary>
        /// 获取全球化资源字符串。
        /// </summary>
        /// <typeparam name="T">值类型。</typeparam>
        /// <param name="templateName">模板名称。</param>
        /// <param name="attributes">属性数组。</param>
        /// <returns></returns>
        protected virtual string GetI18nString<T>(string templateName, params STAttribute<T>[] attributes)
        {
            return GetString(I18nResource.GetString(templateName), attributes);
        }
    }
}
