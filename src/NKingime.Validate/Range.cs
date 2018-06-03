using System;

namespace NKingime.Validate
{
    /// <summary>
    /// 范围。
    /// </summary>
    public class Range<T> where T : struct, IComparable
    {
        /// <summary>
        /// 初始化一个<see cref="Range{T}"/>类型的新实例。
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        public Range(T minValue, T maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        /// <summary>
        /// 最小值。
        /// </summary>
        public T MinValue { get; set; }

        /// <summary>
        /// 最大值。
        /// </summary>
        public T MaxValue { get; set; }
    }
}
