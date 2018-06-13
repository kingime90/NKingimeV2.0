using System;

namespace NKingime.Utility.General
{
    /// <summary>
    /// 键/值项。
    /// </summary>
    /// <typeparam name="TKey">键类型。</typeparam>
    /// <typeparam name="TValue">值类型。</typeparam>
    public class KeyValueItem<TKey, TValue> : IKeyValueItem<TKey, TValue>
    {
        /// <summary>
        /// 初始化一个<see cref="KeyValueItem{TKey,TValue}"/>类型的新实例。
        /// </summary>
        public KeyValueItem()
        {

        }

        /// <summary>
        /// 初始化一个<see cref="KeyValueItem{TKey,TValue}"/>类型的新实例。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        public KeyValueItem(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// 键。
        /// </summary>
        public TKey Key { get; set; }

        /// <summary>
        /// 值。
        /// </summary>
        public TValue Value { get; set; }
    }
}
