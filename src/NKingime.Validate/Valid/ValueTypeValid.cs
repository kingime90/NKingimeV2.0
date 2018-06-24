using System;

namespace NKingime.Validate.Valid
{
    /// <summary>
    /// 值类型验证。
    /// </summary>
    /// <typeparam name="T">值类型类型。</typeparam>
    public class ValueTypeValid<T> : TypeValidBase, IValueTypeValid<T> where T : struct
    {


        /// <summary>
        /// 设置验证最小值。
        /// </summary>
        /// <param name="value">最小值。</param>
        /// <returns></returns>
        public IValueTypeValid<T> MinValue(T value)
        {
            return this;
        }

        /// <summary>
        /// 设置验证最大值。
        /// </summary>
        /// <param name="value">最大值。</param>
        /// <returns></returns>
        public IValueTypeValid<T> MaxValue(T value)
        {
            return this;
        }

        /// <summary>
        /// 设置验证值范围。
        /// </summary>
        /// <param name="minValue">最小值。</param>
        /// <param name="maxValue">最大值。</param>
        /// <returns></returns>
        public IValueTypeValid<T> Range(T minValue, T maxValue)
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public override ValidResult Validate(object value, string name, string description, object root = null)
        {
            throw new NotImplementedException();
        }
    }
}
