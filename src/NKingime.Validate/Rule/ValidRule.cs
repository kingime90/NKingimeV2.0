using System;

namespace NKingime.Validate
{
    /// <summary>
    /// 验证规则基类。
    /// </summary>
    public abstract class ValidRule: IValidRule
    {
        /// <summary>
        /// 初始化一个<see cref="ValidRule"/>类型的新实例。
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
