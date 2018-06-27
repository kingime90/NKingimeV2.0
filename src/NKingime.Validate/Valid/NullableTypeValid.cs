using System;
using NKingime.Utility.General;
using NKingime.Utility.Exceptions;
using NKingime.Utility.Extensions;
using NKingime.Validate.Properties;

namespace NKingime.Validate
{
    /// <summary>
    /// 可空类型验证。
    /// </summary>
    /// <typeparam name="T">可空类型。</typeparam>
    public class NullableTypeValid<T> : TypeValidBase, INullableTypeValid<T> where T : struct, IComparable
    {
        /// <summary>
        /// 验证规则。
        /// </summary>
        private NullableTypeRule<T> _validRule = new NullableTypeRule<T>();

        /// <summary>
        /// 初始化一个<see cref="NullableTypeValid"/>类型的新实例。
        /// </summary>
        public NullableTypeValid() : base()
        {

        }

        /// <summary>
        /// 初始化一个<see cref="NullableTypeValid"/>类型的新实例。
        /// </summary>
        /// <param name="i18nResource">全球化资源。</param>
        public NullableTypeValid(I18nResourceBase i18nResource) : base(i18nResource)
        {

        }

        /// <summary>
        /// 设置是否必填，默认必填。
        /// </summary>
        /// <param name="isRequired">是否必填。</param>
        /// <returns></returns>
        public INullableTypeValid<T> Required(bool isRequired = true)
        {
            _validRule.IsRequired = isRequired;
            return this;
        }

        /// <summary>
        /// 设置验证最小值。
        /// </summary>
        /// <param name="value">最小值。</param>
        /// <returns></returns>
        public INullableTypeValid<T> MinValue(T value)
        {
            SetTypeRuleRange(ValueTypeCompareOption.MinValue, value, default(T));
            return this;
        }

        /// <summary>
        /// 设置验证最大值。
        /// </summary>
        /// <param name="value">最大值。</param>
        /// <returns></returns>
        public INullableTypeValid<T> MaxValue(T value)
        {
            SetTypeRuleRange(ValueTypeCompareOption.MaxValue, default(T), value);
            return this;
        }

        /// <summary>
        /// 设置验证值范围。
        /// </summary>
        /// <param name="minValue">最小值。</param>
        /// <param name="maxValue">最大值。</param>
        /// <returns></returns>
        public INullableTypeValid<T> Range(T minValue, T maxValue)
        {
            SetTypeRuleRange(ValueTypeCompareOption.Range, minValue, maxValue);
            return this;
        }

        /// <summary>
        /// 设置自定义验证。
        /// </summary>
        /// <param name="valid">自定义验证函数。</param>
        /// <returns></returns>
        public INullableTypeValid<T> Custom(Func<T?, object, BooleanResult> valid)
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
            //必填
            if (_validRule.IsRequired && value.IsNull())
            {
                validResult.SetMessage(GetI18nString(nameof(Validate_zh_CN.RequiredError), PropertyName, description));
                return validResult;
            }
            var t = (T?)value;
            if (t.IsNotNull() && _validRule.CompareOption.HasValue)
            {
                var parameters = new STAttribute<object>[]
                {
                    new STAttribute<object>(PropertyName,description),
                    new STAttribute<object>(MinValueName,_validRule.MinValue),
                    new STAttribute<object>(MaxValueName,_validRule.MaxValue),
                };
                switch (_validRule.CompareOption.Value)
                {
                    case ValueTypeCompareOption.MinValue:
                        if (t.Value.IsLess(_validRule.MinValue))
                        {
                            validResult.SetMessage(GetI18nString(nameof(Validate_zh_CN.ValueTypeMinValueError), parameters));
                            return validResult;
                        }
                        break;
                    case ValueTypeCompareOption.MaxValue:
                        if (t.Value.IsGreater(_validRule.MaxValue))
                        {
                            validResult.SetMessage(GetI18nString(nameof(Validate_zh_CN.ValueTypeMaxValueError), parameters));
                            return validResult;
                        }
                        break;
                    case ValueTypeCompareOption.Range:
                        if (!t.Value.IsRange(_validRule.MinValue, _validRule.MaxValue))
                        {
                            validResult.SetMessage(GetI18nString(nameof(Validate_zh_CN.ValueTypeRangeError), parameters));
                            return validResult;
                        }
                        break;
                    default:
                        throw new UnhandledTypeException(_validRule.CompareOption.Value.GetFullName(), _validRule.CompareOption.Value.GetType().GetDescription());
                }
            }
            //自定义验证函数
            if (_validRule.CustomValid.IsNotNull())
            {
                var messageResult = _validRule.CustomValid(t, root);
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
        /// <param name="compareOption">值类型比较选项。</param>
        /// <param name="minValue">最小值。</param>
        /// <param name="maxValue">最大值。</param>
        private void SetTypeRuleRange(ValueTypeCompareOption compareOption, T minValue, T maxValue)
        {
            _validRule.CompareOption = compareOption;
            _validRule.MinValue = minValue;
            _validRule.MaxValue = maxValue;
        }
    }
}
