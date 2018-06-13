﻿using System;
using NKingime.Utility;
using NKingime.Utility.General;
using NKingime.Utility.Extensions;
using NKingime.Validate.Properties;
using System.Collections.Generic;

namespace NKingime.Validate
{
    /// <summary>
    /// 字符串类型验证。
    /// </summary>
    public class StringTypeValid : TypeValidBase, IStringTypeValid
    {
        /// <summary>
        /// 验证规则。
        /// </summary>
        private StringTypeRule _validRule = new StringTypeRule();

        /// <summary>
        /// 初始化一个<see cref="StringTypeValid"/>类型的新实例。
        /// </summary>
        public StringTypeValid() : base()
        {

        }

        /// <summary>
        /// 初始化一个<see cref="StringTypeValid"/>类型的新实例。
        /// </summary>
        /// <param name="i18nResource">全球化资源。</param>
        public StringTypeValid(I18nResourceBase i18nResource) : base(i18nResource)
        {

        }

        /// <summary>
        /// 设置是否必填，默认必填。
        /// </summary>
        /// <param name="isRequired">是否必填。</param>
        /// <returns></returns>
        public IStringTypeValid Required(bool isRequired = true)
        {
            _validRule.IsRequired = isRequired;
            return this;
        }

        /// <summary>
        /// 指定的字符串类型最小长度。
        /// </summary>
        /// <param name="minValue">最小长度。</param>
        /// <param name="stringType">字符串类型选项，默认 <see cref="StringTypeOption.String"/>。</param>
        /// <returns></returns>
        public IStringTypeValid MinLength(int minValue, StringTypeOption stringType = StringTypeOption.String)
        {
            SetTypeRuleRange(stringType, minValue, 0);
            return this;
        }

        /// <summary>
        /// 指定的字符串类型最大长度。
        /// </summary>
        /// <param name="maxValue">最大长度。</param>
        /// <param name="stringType">字符串类型选项，默认 <see cref="StringTypeOption.String"/>。</param>
        /// <returns></returns>
        public IStringTypeValid MaxLength(int maxValue, StringTypeOption stringType = StringTypeOption.String)
        {
            SetTypeRuleRange(stringType, 0, maxValue);
            return this;
        }

        /// <summary>
        /// 指定的字符串类型长度范围。
        /// </summary>
        /// <param name="minValue">最小长度。</param>
        /// <param name="maxValue">最大长度。</param>
        /// <param name="stringType">字符串类型选项，默认 <see cref="StringTypeOption.String"/>。</param>
        /// <returns></returns>
        public IStringTypeValid LengthRange(int minValue, int maxValue, StringTypeOption stringType = StringTypeOption.String)
        {
            SetTypeRuleRange(stringType, minValue, maxValue);
            return this;
        }

        /// <summary>
        ///  配置正则式。
        /// </summary>
        /// <param name="regexTypes">正则式类型选项数组。</param>
        /// <returns></returns>
        public IStringTypeValid Matchs(params RegexTypeOption[] regexTypes)
        {
            _validRule.RegexTypes = regexTypes;
            return this;
        }

        /// <summary>
        /// 自定义验证。
        /// </summary>
        /// <param name="valid">自定义验证函数。</param>
        /// <returns></returns>
        public IStringTypeValid Custom(Func<string, object, ValidResult> valid)
        {
            _validRule.CustomValid = valid;
            return this;
        }

        /// <summary>
        /// 验证值是否满足规则。
        /// </summary>
        /// <param name="value">需要验证的值。</param>
        /// <param name="description">需要验证的值的描述。</param>
        /// <param name="root">需要验证的值的根对象，如果没有，则为 null。</param>
        /// <returns></returns>
        public override ValidResult Validate(object value, string description, object root = null)
        {
            var validResult = new ValidResult(false);
            string str = (value as string) ?? string.Empty;
            //必填
            if (_validRule.IsRequired && str.IsNullOrWhiteSpace())
            {
                validResult.SetMessage(STUtil.GetString(I18nResource.GetString(nameof(Valid_zh_CN.RequiredError)), PropertyName, description));
                return validResult;
            }
            //字符串长度范围
            if (!str.IsNullOrWhiteSpace() && _validRule.StringType.HasValue)
            {
                int length;
                string rangeErrorName, minValueErrorName, maxValueErrorName;
                switch (_validRule.StringType.Value)
                {
                    case StringTypeOption.String:
                        length = str.Length;
                        rangeErrorName = nameof(Valid_zh_CN.StringLengthRangeError);
                        minValueErrorName = nameof(Valid_zh_CN.MinLengthError);
                        //maxValueErrorName= nameof(Valid_zh_CN);
                        break;
                    case StringTypeOption.Char:
                        length = str.GetByteLength();
                        rangeErrorName = nameof(Valid_zh_CN.CharNumberRangeError);
                        break;
                    default:
                        throw new Exception("未处理的字符串类型选项。");
                }
                var parameters = new KeyValuePair<string, object>[]
                {
                    new KeyValuePair<string, object>(PropertyName,description),
                    new KeyValuePair<string, object>(MinValueName,_validRule.MinValue),
                    new KeyValuePair<string, object>(MaxValueName,_validRule.MaxValue),
                };
                //范围
                if (_validRule.MinValue > 0 && _validRule.MaxValue > 0 && length.IsRange(_validRule.MinValue, _validRule.MaxValue))
                {
                    validResult.SetMessage(STUtil.GetString(I18nResource.GetString(rangeErrorName), parameters));
                    return validResult;
                }
                //最小长度
                if (_validRule.MinValue > 0)
                {

                    return validResult;
                }
                //最大长度
                if (_validRule.MaxValue > 0)
                {

                    return validResult;
                }
            }
            //匹配正则式类型选项
            if (_validRule.RegexTypes.IsNotEmpty())
            {

            }
            //自定义验证函数
            if (_validRule.CustomValid.IsNotNull())
            {
                validResult = _validRule.CustomValid(str, root);
            }
            return validResult;
        }

        /// <summary>
        /// 设置类型验证规则范围。
        /// </summary>
        /// <param name="stringType">字符串类型选项。</param>
        /// <param name="minValue">最小值。</param>
        /// <param name="maxValue">最大值。</param>
        private void SetTypeRuleRange(StringTypeOption stringType, int minValue, int maxValue)
        {
            _validRule.StringType = stringType;
            _validRule.MinValue = minValue;
            _validRule.MaxValue = maxValue;
        }
    }
}
