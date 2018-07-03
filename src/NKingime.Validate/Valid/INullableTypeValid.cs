using System;
using NKingime.Utility.General;

namespace NKingime.Validate
{
    /// <summary>
    /// 定义可空值类型验证接口。
    /// </summary>
    /// <typeparam name="T">可空值类型。</typeparam>
    public interface INullableTypeValid<T> where T : struct, IComparable
    {
        /// <summary>
        /// 设置是否必填，默认必填。
        /// </summary>
        /// <param name="isRequired">是否必填。</param>
        /// <returns></returns>
        INullableTypeValid<T> Required(bool isRequired = true);

        /// <summary>
        /// 设置验证最小值。
        /// </summary>
        /// <param name="value">最小值。</param>
        /// <returns></returns>
        INullableTypeValid<T> MinValue(T value);

        /// <summary>
        /// 设置验证最大值。
        /// </summary>
        /// <param name="value">最大值。</param>
        /// <returns></returns>
        INullableTypeValid<T> MaxValue(T value);

        /// <summary>
        /// 设置验证值范围。
        /// </summary>
        /// <param name="minValue">最小值。</param>
        /// <param name="maxValue">最大值。</param>
        /// <returns></returns>
        INullableTypeValid<T> Range(T minValue, T maxValue);

        /// <summary>
        /// 设置自定义验证。
        /// </summary>
        /// <param name="valid">自定义验证函数。</param>
        /// <returns></returns>
        INullableTypeValid<T> Custom(Func<T?, object, BooleanResult> valid);
    }
}
