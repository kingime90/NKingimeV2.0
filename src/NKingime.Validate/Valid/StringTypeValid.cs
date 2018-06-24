using System;
using NKingime.Utility;
using NKingime.Validate.Valid;
using NKingime.Utility.General;
using NKingime.Utility.Extensions;
using NKingime.Utility.Exceptions;
using NKingime.Validate.Properties;

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
        /// 设置指定的字符串类型最小长度。
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
        /// 设置指定的字符串类型最大长度。
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
        /// 设置指定的字符串类型长度或字符个数范围。
        /// </summary>
        /// <param name="minValue">最小长度。</param>
        /// <param name="maxValue">最大长度。</param>
        /// <param name="stringType">字符串类型选项，默认 <see cref="StringTypeOption.String"/>。</param>
        /// <returns></returns>
        public IStringTypeValid Range(int minValue, int maxValue, StringTypeOption stringType = StringTypeOption.String)
        {
            SetTypeRuleRange(stringType, minValue, maxValue);
            return this;
        }

        /// <summary>
        ///  设置配置正则式。
        /// </summary>
        /// <param name="regexTypes">正则式类型选项数组。</param>
        /// <returns></returns>
        public IStringTypeValid Matchs(params RegexTypeOption[] regexTypes)
        {
            _validRule.RegexTypes = regexTypes;
            return this;
        }

        /// <summary>
        /// 设置自定义验证。
        /// </summary>
        /// <param name="valid">自定义验证函数。</param>
        /// <returns></returns>
        public IStringTypeValid Custom(Func<string, object, ValidMessageResult> valid)
        {
            _validRule.CustomValid = valid;
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
                        minValueErrorName = nameof(Valid_zh_CN.StringMinLengthError);
                        maxValueErrorName = nameof(Valid_zh_CN.StringMaxLengthError);
                        break;
                    case StringTypeOption.Char:
                        length = str.GetByteLength();
                        rangeErrorName = nameof(Valid_zh_CN.CharNumberRangeError);
                        minValueErrorName = nameof(Valid_zh_CN.MinCharNumberError);
                        maxValueErrorName = nameof(Valid_zh_CN.MaxCharNumberError);
                        break;
                    default:
                        throw new UnhandledTypeException(_validRule.StringType.Value.GetFullName(), _validRule.StringType.Value.GetType().GetDescription());
                }
                var parameters = new STAttribute<object>[]
                {
                    new STAttribute<object>(PropertyName,description),
                    new STAttribute<object>(MinValueName,_validRule.MinValue),
                    new STAttribute<object>(MaxValueName,_validRule.MaxValue),
                };
                //范围
                if (_validRule.MinValue > 0 && _validRule.MaxValue > 0 && !length.IsRange(_validRule.MinValue, _validRule.MaxValue))
                {
                    validResult.SetMessage(STUtil.GetString(I18nResource.GetString(rangeErrorName), parameters));
                    return validResult;
                }
                //最小长度
                if (_validRule.MinValue > 0 && length.IsLess(_validRule.MinValue))
                {
                    validResult.SetMessage(STUtil.GetString(I18nResource.GetString(minValueErrorName), parameters));
                    return validResult;
                }
                //最大长度
                if (_validRule.MaxValue > 0 && length.IsGreater(_validRule.MaxValue))
                {
                    validResult.SetMessage(STUtil.GetString(I18nResource.GetString(maxValueErrorName), parameters));
                    return validResult;
                }
            }
            //匹配正则式类型选项
            ValidMessageResult messageResult;
            if (_validRule.RegexTypes.IsNotEmpty())
            {
                var regexValid = new RegexValid(I18nResource, _validRule.RegexTypes);
                messageResult = regexValid.Validate(str);
                if (!messageResult.Result)
                {
                    validResult.SetMessage(messageResult.Message);
                    return validResult;
                }
            }
            //自定义验证函数
            if (_validRule.CustomValid.IsNotNull())
            {
                messageResult = _validRule.CustomValid(str, root);
                if (!messageResult.Result)
                {
                    validResult.SetMessage(messageResult.Message);
                    return validResult;
                }
            }
            return validResult.Reset(true);
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
