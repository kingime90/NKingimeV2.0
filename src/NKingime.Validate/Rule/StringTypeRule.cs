using System;

namespace NKingime.Validate
{
    /// <summary>
    /// 字符串类型验证规则。
    /// </summary>
    public class StringTypeRule : ValidRule
    {
        /// <summary>
        /// 字符串范围选项。
        /// </summary>
        public StringRangeOption? RangeOption { get; set; }

        /// <summary>
        /// 最小值。
        /// </summary>
        public int MinValue { get; set; }

        /// <summary>
        /// 最大值。
        /// </summary>
        public int MaxValue { get; set; }
    }
}
