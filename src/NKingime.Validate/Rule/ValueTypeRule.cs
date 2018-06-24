using System;

namespace NKingime.Validate
{
    /// <summary>
    /// 值类型验证规则。
    /// </summary>
    public class ValueTypeRule<T> : IValidRule where T : struct
    {
        /// <summary>
        /// 获取或设置 最小值。
        /// </summary>
        public T MinValue { get; set; }

        /// <summary>
        /// 获取或设置 最大值。
        /// </summary>
        public T MaxValue { get; set; }
    }
}
