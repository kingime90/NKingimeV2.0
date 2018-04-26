using System;

namespace NKingime.Core.Reflection
{
    /// <summary>
    /// 定义一个查找器。
    /// </summary>
    /// <typeparam name="TItem">要查找的项类型。</typeparam>
    public interface IFinder<out TItem>
    {
        /// <summary>
        /// 查找指定条件的项。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        TItem[] Find(Func<TItem, bool> predicate);

        /// <summary>
        /// 查找所有项。
        /// </summary>
        /// <returns></returns>
        TItem[] FindAll();
    }
}