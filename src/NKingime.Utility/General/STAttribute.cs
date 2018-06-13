using System;

namespace NKingime.Utility.General
{
    /// <summary>
    /// 字符串模板属性（StringTemplate）。
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public class STAttribute<TValue> : ReadOnlyKeyValue<string, TValue>
    {
        /// <summary>
        /// 初始化一个<see cref="STAttribute{TValue}"/>类型的新实例。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        public STAttribute(string key, TValue value) : base(key, value)
        {

        }
    }
}
