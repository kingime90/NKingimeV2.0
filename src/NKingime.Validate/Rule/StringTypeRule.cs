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

        /// <summary>
        /// 匹配正则式类型选项数组。
        /// </summary>
        public RegexTypeOption[] RegexTypes { get; set; }

        /// <summary>
        /// 自定义验证函数。
        /// </summary>
        public Func<object, string, ValidResult> CustomValid { get; set; }
    }
}
