using System;

namespace NKingime.Validate
{
    /// <summary>
    /// 验证规则。
    /// </summary>
    public abstract class ValidRule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isRequired"></param>
        public ValidRule(bool isRequired = false)
        {
            IsRequired = isRequired;
        }

        /// <summary>
        /// 是否必填。
        /// </summary>
        public bool IsRequired { get; set; }
    }
}
