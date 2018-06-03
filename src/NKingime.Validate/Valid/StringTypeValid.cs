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
            SetTypeRule(StringRangeOption.String, minValue, 0);
            return this;
        }

        /// <summary>
        /// 字符串最大长度。
        /// </summary>
        /// <param name="maxValue">最大长度。</param>
        /// <returns></returns>
        public IStringTypeValid MaxLength(int maxValue)
        {
            SetTypeRule(StringRangeOption.String, 0, maxValue);
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
            SetTypeRule(StringRangeOption.String, minValue, maxValue);
            return this;
        }

        /// <summary>
        /// 字符最小个数。
        /// </summary>
        /// <param name="minValue">最小个数。</param>
        /// <returns></returns>
        public IStringTypeValid CharMinLength(int minValue)
        {
            SetTypeRule(StringRangeOption.Char, minValue, 0);
            return this;
        }

        /// <summary>
        /// 字符最大个数。
        /// </summary>
        /// <param name="maxValue">最大个数。</param>
        /// <returns></returns>
        public IStringTypeValid CharMaxLength(int maxValue)
        {
            SetTypeRule(StringRangeOption.Char, 0, maxValue);
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
            SetTypeRule(StringRangeOption.Char, minValue, maxValue);
            return this;
        }

        /// <summary>
        /// 验证数据是否满足规则。
        /// </summary>
        /// <param name="obj">需要验证的数据。</param>
        /// <returns></returns>
        public ValidResult Validate(object obj)
        {
            var validResult = new ValidResult(false);
            string value = obj as string;
            if (_validRule.IsRequired && value.IsNullOrWhiteSpace())
            {
                validResult.SetMessage("");
                return validResult;
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// 设置类型验证规则。
        /// </summary>
        /// <param name="rangeOption">字符串范围选项。</param>
        /// <param name="minValue">最小值。</param>
        /// <param name="maxValue">最大值。</param>
        private void SetTypeRule(StringRangeOption rangeOption, int minValue, int maxValue)
        {
            _validRule.RangeOption = rangeOption;
            _validRule.MinValue = minValue;
            _validRule.MaxValue = maxValue;
        }
    }
}
