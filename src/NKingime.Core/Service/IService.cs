using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NKingime.Core.Entity;
using NKingime.Core.Dependency;
using NKingime.Utility.General;

namespace NKingime.Core.Service
{
    /// <summary>
    /// 定义数据实体服务接口。
    /// </summary>
    /// <typeparam name="TEntity">数据实体类型。</typeparam>
    /// <typeparam name="TKey">主键类型。</typeparam>
    public interface IService<TEntity, TKey> : IService where TEntity : class, IEntity<TKey> where TKey : IEquatable<TKey>
    {
        #region 删除

        /// <summary>
        /// 根据主键删除数据实体。
        /// </summary>
        /// <param name="key">主键。</param>
        /// <param name="valid">验证数据实体受限制函数。</param>
        /// <returns>返回操作结果。</returns>
        DeleteResult DeleteByKey(TKey key, Func<TEntity, DeleteResult> valid = null);

        #endregion

        #region 查询

        /// <summary>
        /// 是否存在符合指定筛选表达式的数据。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="key">排除的主键值。</param>
        /// <returns></returns>
        bool Exists(Expression<Func<TEntity, bool>> predicate, TKey key = default(TKey));

        /// <summary>
        /// 根据主键获取数据实体。
        /// </summary>
        /// <param name="key">主键。</param>
        /// <returns>如果检索到记录，则返回数据实体，否则返回null。</returns>
        TEntity GetByKey(TKey key);

        /// <summary>
        /// 获取第一个或默认的数据实体。
        /// </summary>
        /// <returns>如果检索到记录，则返回第一个数据实体，否则返回null。/returns>
        TEntity FirstOrDefault();

        /// <summary>
        /// 根据指定筛选表达式获取第一个或默认的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns>如果检索到记录，则返回第一个数据实体，否则返回null。/returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 获取第一个或默认的数据实体。
        /// </summary>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns>如果检索到记录，则返回第一个数据实体，否则返回null。/returns>
        TEntity FirstOrDefault(params OrderSelector<TEntity>[] orderSelectors);

        /// <summary>
        /// 根据指定筛选表达式获取第一个或默认的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns>如果检索到记录，则返回第一个数据实体，否则返回null。/returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors);

        /// <summary>
        /// 查询所有数据实体列表（非跟踪查询）。
        /// </summary>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        List<TEntity> Query(params OrderSelector<TEntity>[] orderSelectors);

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（非跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        List<TEntity> Query(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（非跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        List<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors);

        /// <summary>
        /// 查询所有数据实体列表（跟踪查询）。
        /// </summary>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        List<TEntity> QueryTrack(params OrderSelector<TEntity>[] orderSelectors);

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        List<TEntity> QueryTrack(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        List<TEntity> QueryTrack(Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors);

        #endregion

        #region 分页

        /// <summary>
        /// 分页列表。
        /// </summary>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <returns></returns>
        IPagedResult<TEntity> PagedList(int pageSize, int pageIndex);

        /// <summary>
        /// 分页列表。
        /// </summary>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        IPagedResult<TEntity> PagedList(int pageSize, int pageIndex, params OrderSelector<TEntity>[] orderSelectors);

        /// <summary>
        /// 分页列表。
        /// </summary>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        IPagedResult<TEntity> PagedList(int pageSize, int pageIndex, Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 分页列表。
        /// </summary>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        IPagedResult<TEntity> PagedList(int pageSize, int pageIndex, Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors);

        #endregion

        #region 函数

        /// <summary>
        /// 返回实体集合中满足条件的的元素数量。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate);

        #endregion
    }

    /// <summary>
    /// 定义数据服务接口。
    /// </summary>
    public interface IService : IScopeDependency
    {

    }
}
