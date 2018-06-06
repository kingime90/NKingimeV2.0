using System;
using NKingime.Utility.Extensions;

namespace NKingime.Validate
{
    /// <summary>
    /// 字符串类型验证。
    /// </summary>
    public class StringTypeValid : IStringTypeValid
    {

        private StringTypeRule _validRule = new StringTypeRule();

        /// <summary>
        /// 获取 验证规则。
        /// </summary>
        public ValidRule ValidRule
        {
            get
            {
                return _validRule;
            }
        }

        /// <summary>
        /// 设置是否必填，默认必填。
        /// </summary>
        /// <param name="isRequired">是否必填。</param>
        /// <returns></returns>
        public IStringTypeValid Required(bool isRequired = true)
        {
            _validRule.IsRequired = true;
            return this;
        }

        /// <summary>
        /// 字符串最小长度。
        /// </summary>
        /// <param name="minValue">最小长度。</param>
        /// <returns></returns>
        public IStringTypeValid MinLength(int minValue)
        {
            SetTypeRuleRange(StringTypeOption.String, minValue, 0);
            return this;
        }

        /// <summary>
        /// 字符串最大长度。
        /// </summary>
        /// <param name="maxValue">最大长度。</param>
        /// <returns></returns>
        public IStringTypeValid MaxLength(int maxValue)
        {
            SetTypeRuleRange(StringTypeOption.String, 0, maxValue);
            return this;
        }

        /// <summary>
        /// 字符串长度范围。
        /// </summary>
        /// <param name="minValue">最小长度。</param>
        /// <param name="maxValue">最大长度。</param>
        /// <returns></returns>
        public IStringTypeValid Range(int minValue, int maxValue)
        {
            SetTypeRuleRange(StringTypeOption.String, minValue, maxValue);
            return this;
        }

        /// <summary>
        /// 字符最小个数。
        /// </summary>
        /// <param name="minValue">最小个数。</param>
        /// <returns></returns>
        public IStringTypeValid CharMinLength(int minValue)
        {
            SetTypeRuleRange(StringTypeOption.Char, minValue, 0);
            return this;
        }

        /// <summary>
        /// 字符最大个数。
        /// </summary>
        /// <param name="maxValue">最大个数。</param>
        /// <returns></returns>
        public IStringTypeValid CharMaxLength(int maxValue)
        {
            SetTypeRuleRange(StringTypeOption.Char, 0, maxValue);
            return this;
        }

        /// <summary>
        /// 字符个数范围。
        /// </summary>
        /// <param name="minValue">最小个数。</param>
        /// <param name="maxValue">最大个数。</param>
        /// <returns></returns>
        public IStringTypeValid CharRange(int minValue, int maxValue)
        {
            SetTypeRuleRange(StringTypeOption.Char, minValue, maxValue);
            return this;
        }

        /// <summary>
        ///  配置正则式。
        /// </summary>
        /// <param name="regexTypes">正则式类型选项数组。</param>
        /// <returns></returns>
        public IStringTypeValid Match(params RegexTypeOption[] regexTypes)
        {
            _validRule.RegexTypes = regexTypes;
            return this;
        }

        /// <summary>
        /// 自定义验证。
        /// </summary>
        /// <param name="valid">自定义验证函数。</param>
        /// <returns></returns>
        public IStringTypeValid Custom(Func<object, string, ValidResult> valid)
        {
            _validRule.CustomValid = valid;
            return this;
        }

        /// <summary>
        /// 验证数据是否满足规则。
        /// </summary>
        /// <param name="value">需要验证的值。</param>
        /// <param name="root">需要验证的根对象，如果没有，则为 null。</param>
        /// <returns></returns>
        public ValidResult Validate(object value, object root = null)
        {
            var validResult = new ValidResult(false);
            string str = (value as string) ?? string.Empty;
            //必填
            if (_validRule.IsRequired && str.IsNullOrWhiteSpace())
            {
                validResult.SetMessage("");
                return validResult;
            }
            //字符串长度范围
            if (_validRule.StringType.HasValue)
            {
                switch (_validRule.StringType.Value)
                {
                    case StringTypeOption.String:

                        break;
                    case StringTypeOption.Char:

                        break;
                    default:
                        throw new Exception("未处理的字符串类型选项。");
                }
            }
            //匹配正则式类型选项
            if (_validRule.RegexTypes.IsNotEmpty())
            {

            }
            //自定义验证函数
            if (_validRule.CustomValid.IsNotNull())
            {
                validResult = _validRule.CustomValid(root, str);
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
