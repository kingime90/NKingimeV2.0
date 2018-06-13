using System;

namespace NKingime.Utility.General
{
    /// <summary>
    /// 定义键/值项接口。
    /// </summary>
    /// <typeparam name="TKey">键类型。</typeparam>
    /// <typeparam name="TValue">值类型。</typeparam>
    public interface IKeyValueItem<TKey, TValue>
    {
        /// <summary>
        /// 键。
        /// </summary>
        TKey Key { get; }

        /// <summary>
        /// 值。
        /// </summary>
        TValue Value { get; }
    }
}
