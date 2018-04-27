using System;
using System.Linq;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Collections.Generic;
using NKingime.Utility.General;

namespace NKingime.Utility
{
    /// <summary>
    /// 排序选择器应用。
    /// </summary>
    public static class OrderUtil
    {
        /// <summary>
        /// 按升序排序。
        /// </summary>
        /// <param name="keySelectors"></param>
        /// <returns></returns>
        public static OrderSelector<TEntity> Ascending<TEntity>(IList<Expression<Func<TEntity, dynamic>>> keySelectors) where TEntity : class
        {
            return new OrderSelector<TEntity>(keySelectors);
        }

        /// <summary>
        /// 按升序排序。
        /// </summary>
        /// <param name="keySelectors"></param>
        /// <returns></returns>
        public static OrderSelector<TEntity> Ascending<TEntity>(params Expression<Func<TEntity, dynamic>>[] keySelectors) where TEntity : class
        {
            return new OrderSelector<TEntity>(keySelectors);
        }

        /// <summary>
        /// 按降序排序。
        /// </summary>
        /// <param name="keySelectors"></param>
        /// <returns></returns>
        public static OrderSelector<TEntity> Descending<TEntity>(IList<Expression<Func<TEntity, dynamic>>> keySelectors) where TEntity : class
        {
            return new OrderSelector<TEntity>(ListSortDirection.Descending, keySelectors);
        }

        /// <summary>
        /// 按降序排序。
        /// </summary>
        /// <param name="keySelectors"></param>
        /// <returns></returns>
        public static OrderSelector<TEntity> Descending<TEntity>(params Expression<Func<TEntity, dynamic>>[] keySelectors) where TEntity : class
        {
            return new OrderSelector<TEntity>(ListSortDirection.Descending, keySelectors);
        }

        /// <summary>
        /// 根据指定排序选择器集合排序。
        /// </summary>
        /// <param name="queryable">提供对数据类型已知的特定数据源的查询进行计算的功能。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public static IOrderedQueryable<TEntity> OrderBy<TEntity>(IQueryable<TEntity> queryable, params OrderSelector<TEntity>[] orderSelectors) where TEntity : class
        {
            int index = 0;
            bool isAscending;
            IOrderedQueryable<TEntity> orderedQueryable = null;
            foreach (var orderSelector in orderSelectors)
            {
                isAscending = orderSelector.SortDirection == ListSortDirection.Ascending;
                foreach (var keySelector in orderSelector.KeySelectors)
                {
                    if (index == 0)
                    {
                        orderedQueryable = isAscending ? queryable.OrderBy(keySelector) : queryable.OrderByDescending(keySelector);
                    }
                    else
                    {
                        orderedQueryable = isAscending ? orderedQueryable.ThenBy(keySelector) : orderedQueryable.ThenByDescending(keySelector);
                    }
                    //
                    index++;
                }
            }
            return orderedQueryable;
        }
    }
}
