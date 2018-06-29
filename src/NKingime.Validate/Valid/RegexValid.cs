using System;
using NKingime.Utility;
using NKingime.Utility.General;
using NKingime.Validate.Properties;
using NKingime.Utility.Exceptions;
using NKingime.Utility.Extensions;

namespace NKingime.Validate
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
        public BooleanResult Validate(string value)
        {
            var messageResult = new BooleanResult(false);
            foreach (var regexType in RegexTypes)
            {
                switch (regexType)
                {
                    case RegexTypeOption.Email:
                        if (!RegexUtil.IsEmail(value))
                        {
                            messageResult.SetMessage(I18nResource.GetString(nameof(Validate_zh_CN.EmailError)));
                            return messageResult;
                        }
                        break;
                    case RegexTypeOption.Chinese:
                        if (!RegexUtil.IsChinese(value))
                        {
                            messageResult.SetMessage(I18nResource.GetString(nameof(Validate_zh_CN.ChineseError)));
                            return messageResult;
                        }
                        break;
                    case RegexTypeOption.URL:
                        if (!RegexUtil.IsURL(value))
                        {
                            messageResult.SetMessage(I18nResource.GetString(nameof(Validate_zh_CN.URLError)));
                            return messageResult;
                        }
                        break;
                    case RegexTypeOption.Letter:
                        if (!RegexUtil.IsLetter(value))
                        {
                            messageResult.SetMessage(I18nResource.GetString(nameof(Validate_zh_CN.LetterError)));
                            return messageResult;
                        }
                        break;
                    case RegexTypeOption.LowerLetter:
                        if (!RegexUtil.IsLowerLetter(value))
                        {
                            messageResult.SetMessage(I18nResource.GetString(nameof(Validate_zh_CN.LowerLetterError)));
                            return messageResult;
                        }
                        break;
                    case RegexTypeOption.UpperLetter:
                        if (!RegexUtil.IsUpperLetter(value))
                        {
                            messageResult.SetMessage(I18nResource.GetString(nameof(Validate_zh_CN.UpperLetterError)));
                            return messageResult;
                        }
                        break;
                    case RegexTypeOption.Cellphone:
                        if (!RegexUtil.IsCellphone(value))
                        {
                            messageResult.SetMessage(I18nResource.GetString(nameof(Validate_zh_CN.CellphoneError)));
                            return messageResult;
                        }
                        break;
                    default:
                        throw new UnhandledTypeException(regexType.GetFullName(), regexType.GetType().GetDescription());
                }
            }
            messageResult.SetResult(true);
            return messageResult;
        }
    }
}
