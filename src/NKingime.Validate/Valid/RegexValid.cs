using System;
using NKingime.Utility;
using NKingime.Utility.General;
using NKingime.Validate.Properties;

namespace NKingime.Validate.Valid
{
    /// <summary>
    /// 正则表达式验证。
    /// </summary>
    public class RegexValid
    {
        /// <summary>
        /// 初始化一个<see cref="RegexValid"/>类型的新实例。
        /// </summary>
        /// <param name="i18nResource">全球化资源。</param>
        /// <param name="regexTypes">匹配正则式类型选项数组。</param>
        public RegexValid(I18nResourceBase i18nResource, params RegexTypeOption[] regexTypes)
        {
            I18nResource = i18nResource;
            RegexTypes = regexTypes;
        }

        /// <summary>
        /// 全球化资源。
        /// </summary>
        public I18nResourceBase I18nResource { get; }

        /// <summary>
        /// 匹配正则式类型选项数组。
        /// </summary>
        public RegexTypeOption[] RegexTypes { get; }

        /// <summary>
        /// 验证值是否满足规则。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public ValidMessageResult Validate(string value)
        {
            var messageResult = new ValidMessageResult(false);
            foreach (var regexType in RegexTypes)
            {
                switch (regexType)
                {
                    case RegexTypeOption.Email:
                        if (!RegexUtil.IsEmail(value))
                        {
                            messageResult.SetMessage(I18nResource.GetString(nameof(Valid_zh_CN.EmailError)));
                            return messageResult;
                        }
                        break;
                    case RegexTypeOption.Chinese:
                        if (!RegexUtil.IsChinese(value))
                        {
                            messageResult.SetMessage(I18nResource.GetString(nameof(Valid_zh_CN.ChineseError)));
                            return messageResult;
                        }
                        break;
                    case RegexTypeOption.URL:
                        if (!RegexUtil.IsURL(value))
                        {
                            messageResult.SetMessage(I18nResource.GetString(nameof(Valid_zh_CN.URLError)));
                            return messageResult;
                        }
                        break;
                    default:
                        throw new Exception("未处理的正则式类型选项。");
                }
            }
            messageResult.SetResult(true);
            return messageResult;
        }
    }
}
