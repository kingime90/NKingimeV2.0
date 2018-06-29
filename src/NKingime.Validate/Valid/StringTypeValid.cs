using System;
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
            SetTypeRuleRange(stringType, ValueTypeCompareOption.MinValue, minValue, 0);
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
            SetTypeRuleRange(stringType, ValueTypeCompareOption.MaxValue, 0, maxValue);
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
            SetTypeRuleRange(stringType, ValueTypeCompareOption.Range, minValue, maxValue);
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
        public IStringTypeValid Custom(Func<string, object, BooleanResult> valid)
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
            var isNullOrWhiteSpace = str.IsNullOrWhiteSpace();
            if (_validRule.IsRequired && isNullOrWhiteSpace)
            {
                validResult.SetMessage(GetI18nString(nameof(Validate_zh_CN.RequiredError), PropertyName, description));
                return validResult;
            }
            BooleanResult messageResult;
            //字符串长度范围
            if (!isNullOrWhiteSpace)
            {
                if (_validRule.StringType.HasValue && _validRule.CompareOption.HasValue)
                {
                    int length;
                    string rangeErrorName, minValueErrorName, maxValueErrorName;
                    switch (_validRule.StringType.Value)
                    {
                        case StringTypeOption.String:
                            length = str.Length;
                            rangeErrorName = nameof(Validate_zh_CN.StringLengthRangeError);
                            minValueErrorName = nameof(Validate_zh_CN.StringMinLengthError);
                            maxValueErrorName = nameof(Validate_zh_CN.StringMaxLengthError);
                            break;
                        case StringTypeOption.Byte:
                            length = str.GetByteLength();
                            rangeErrorName = nameof(Validate_zh_CN.ByteLengthRangeError);
                            minValueErrorName = nameof(Validate_zh_CN.MinByteLengthError);
                            maxValueErrorName = nameof(Validate_zh_CN.MaxByteLengthError);
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
                    switch (_validRule.CompareOption.Value)
                    {
                        //最小长度
                        case ValueTypeCompareOption.MinValue:
                            if (length.IsLess(_validRule.MinValue))
                            {
                                validResult.SetMessage(GetI18nString(minValueErrorName, parameters));
                                return validResult;
                            }
                            break;
                        //最大长度
                        case ValueTypeCompareOption.MaxValue:
                            if (length.IsGreater(_validRule.MaxValue))
                            {
                                validResult.SetMessage(GetI18nString(maxValueErrorName, parameters));
                                return validResult;
                            }
                            break;
                        //范围
                        case ValueTypeCompareOption.Range:
                            if (!length.IsRange(_validRule.MinValue, _validRule.MaxValue))
                            {
                                validResult.SetMessage(GetI18nString(I18nResource.GetString(rangeErrorName), parameters));
                                return validResult;
                            }
                            break;
                        default:
                            throw new UnhandledTypeException(_validRule.CompareOption.Value.GetFullName(), _validRule.CompareOption.Value.GetType().GetDescription());
                    }
                }
                //匹配正则式类型选项
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
        private void SetTypeRuleRange(StringTypeOption stringType, ValueTypeCompareOption compareOption, int minValue, int maxValue)
        {
            _validRule.StringType = stringType;
            _validRule.CompareOption = compareOption;
            _validRule.MinValue = minValue;
            _validRule.MaxValue = maxValue;
        }
    }
}
