using System;
using NKingime.Utility.General;

namespace NKingime.Validate
{
    /// <summary>
    /// 字符串类型验证规则。
    /// </summary>
    public class StringTypeRule : ValidRule
    {
        /// <summary>
        /// 初始化一个<see cref="StringTypeRule"/>类型的新实例。
        /// </summary>
        /// <param name="isRequired"></param>
        public StringTypeRule(bool isRequired = false) : base(isRequired)
        {

        }

        /// <summary>
        /// 字符串类型选项。
        /// </summary>
        public StringTypeOption? StringType { get; set; }

        /// <summary>
        /// 比较选项。
        /// </summary>
        public ValueTypeCompareOption? CompareOption { get; set; }

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
        public Func<string, object, BooleanResult> CustomValid { get; set; }
    }
}
