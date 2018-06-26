using System;

namespace NKingime.Validate
{
    /// <summary>
    /// 定义值类型验证接口。
    /// </summary>
    /// <typeparam name="T">值类型类型。</typeparam>
    public interface IValueTypeValid<T> where T : struct, IComparable
    {
        /// <summary>
        /// 设置验证最小值。
        /// </summary>
        /// <param name="value">最小值。</param>
        /// <returns></returns>
        IValueTypeValid<T> MinValue(T value);

        /// <summary>
        /// 设置验证最大值。
        /// </summary>
        /// <param name="value">最大值。</param>
        /// <returns></returns>
        IValueTypeValid<T> MaxValue(T value);

        /// <summary>
        /// 设置验证值范围。
        /// </summary>
        /// <param name="minValue">最小值。</param>
        /// <param name="maxValue">最大值。</param>
        /// <returns></returns>
        IValueTypeValid<T> Range(T minValue, T maxValue);

        /// <summary>
        /// 设置自定义验证。
        /// </summary>
        /// <param name="valid">自定义验证函数。</param>
        /// <returns></returns>
        IValueTypeValid<T> Custom(Func<T, object, ValidMessageResult> valid);
    }
}
