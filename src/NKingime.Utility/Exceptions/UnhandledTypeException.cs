using System;
using NKingime.Utility.General;
using NKingime.Utility.Properties;

namespace NKingime.Utility.Exceptions
{
    /// <summary>
    /// 未处理类型异常。
    /// </summary>
    public class UnhandledTypeException : Exception
    {
        /// <summary>
        /// 初始化一个<see cref="UnhandledTypeException"/>类型的新实例。
        /// </summary>
        /// <param name="typeName">类型名称。</param>
        /// <param name="description">描述。</param>
        public UnhandledTypeException(string typeName, string description, I18nResourceBase i18nResource = null)
        {
            if (i18nResource == null)
            {
                i18nResource = new UtilityResource();
            }
            I18nResource = i18nResource;
            Message = GetMessage(typeName, description);
        }

        /// <summary>
        /// 获取描述当前异常的消息。
        /// </summary>
        public override string Message { get; }

        /// <summary>
        /// 全球化资源。
        /// </summary>
        public I18nResourceBase I18nResource { get; }

        /// <summary>
        /// 获取描述当前异常的消息。
        /// </summary>
        /// <param name="typeName">类型名称。</param>
        /// <param name="description">描述。</param>
        /// <returns></returns>
        protected string GetMessage(string typeName, string description)
        {
            var parameters = new STAttribute<string>[]
            {
                new STAttribute<string>(nameof(typeName),typeName),
                new STAttribute<string>(nameof(description),description),
            };
            return STUtil.GetString(I18nResource.GetString(nameof(Utility_zh_CN.UnhandledTypeError)), parameters);
        }
    }
}
