using System;
using NKingime.Utility.General;

namespace NKingime.Validate
{
    /// <summary>
    /// 可空类型验证规则。
    /// </summary>
    /// <typeparam name="T">可空类型。</typeparam>
    public class NullableTypeRule<T> : ValidRule where T : struct, IComparable
    {
        /// <summary>
        /// 初始化一个<see cref="NullableTypeRule{T}"/>类型的新实例。
        /// </summary>
        /// <param name="isRequired"></param>
        public NullableTypeRule(bool isRequired = false) : base(isRequired)
        {

        }

        /// <summary>
        /// 获取或设置 比较选项。
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
        public Func<T?, object, BooleanResult> CustomValid { get; set; }
    }
}
