using System;

namespace NKingime.Validate
{
    /// <summary>
    /// 字符串类型验证。
    /// </summary>
    public class StringTypeValid : IStringTypeValid
    {
        /// <summary>
        /// 
        /// </summary>
        public StringTypeValid()
        {
            _validRule = new StringTypeRule();
        }

        private StringTypeRule _validRule;

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
        /// 验证数据是否满足规则。
        /// </summary>
        /// <param name="value">值。</param>
        /// <returns></returns>
        public ValidResult Validate(object value)
        {

            throw new NotImplementedException();
        }
    }
}
