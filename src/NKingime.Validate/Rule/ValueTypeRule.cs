using System;
using NKingime.Utility.General;

namespace NKingime.Validate
{
    /// <summary>
    /// 值类型验证规则。
    /// </summary>
    /// <typeparam name="T">值类型。</typeparam>
    public class ValueTypeRule<T> : IValidRule where T : struct, IComparable
    {
        /// <summary>
        /// 比较选项。
        /// </summary>
        public ValueTypeCompareOption? CompareOption { get; set; }

        /// <summary>
        /// 获取或设置 最小值。
        /// </summary>
        public T MinValue { get; set; }

        /// <summary>
        /// 获取或设置 最大值。
        /// </summary>
        public T MaxValue { get; set; }

        /// <summary>
        /// 自定义验证函数。
        /// </summary>
        public Func<T, object, BooleanResult> CustomValid { get; set; }
    }
}
