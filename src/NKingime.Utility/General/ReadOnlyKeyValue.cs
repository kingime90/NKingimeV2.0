using System;

namespace NKingime.Utility.General
{
    /// <summary>
    /// 只读键/值项
    /// </summary>
    public class ReadOnlyKeyValue<TKey, TValue> : IKeyValueItem<TKey, TValue>
    {
        /// <summary>
        /// 初始化一个<see cref="ReadOnlyKeyValue{TKey,TValue}"/>类型的新实例。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        public ReadOnlyKeyValue(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// 键。
        /// </summary>
        public TKey Key { get; }

        /// <summary>
        /// 值。
        /// </summary>
        public TValue Value { get; }
    }
}
