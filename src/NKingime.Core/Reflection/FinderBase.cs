using System;
using System.Linq;

namespace NKingime.Core.Reflection
{
    /// <summary>
    /// 查找器基类。
    /// </summary>
    /// <typeparam name="TItem">要查找的项类型。</typeparam>
    public abstract class FinderBase<TItem> : IFinder<TItem>
    {
        /// <summary>
        /// 查找指定条件的项。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        public virtual TItem[] Find(Func<TItem, bool> predicate)
        {
            return FindAll().Where(predicate).ToArray();
        }

        /// <summary>
        /// 查找所有项。
        /// </summary>
        /// <returns></returns>
        public abstract TItem[] FindAll();
    }
}
