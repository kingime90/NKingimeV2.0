using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NKingime.Core.Data;
using NKingime.Core.Entity;
using NKingime.Core.Option;
using NKingime.Utility.General;
using NKingime.Utility.Extensions;

namespace NKingime.Core.Service
{
    /// <summary>
    /// 数据实体服务基类。
    /// </summary>
    /// <typeparam name="TEntity">数据实体类型。</typeparam>
    /// <typeparam name="TKey">主键类型。</typeparam>
    public abstract class ServiceBase<TEntity, TKey> : IService<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 当前数据实体仓储。
        /// </summary>
        private IRepository<TEntity, TKey> _entityRepository;

        /// <summary>
        /// 初始化一个<see cref="ServiceBase{TEntity,TKey}"/>新实例。
        /// </summary>
        /// <param name="entityRepository"></param>
        public ServiceBase(IRepository<TEntity, TKey> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        /// <summary>
        /// 更新数据实体并检查约束。
        /// </summary>
        /// <param name="entity">数据实体。</param>
        /// <param name="constraint">检查约束函数，并返回检查结果。</param>
        /// <returns></returns>
        public UpdateResult UpdateWithConstraint(TEntity entity, Func<TEntity, CheckResult> constraint = null)
        {
            var operateResult = new UpdateResult();

            return operateResult;
        }

        #region 删除

        /// <summary>
        /// 根据主键删除数据实体并检查约束。
        /// </summary>
        /// <param name="key">主键。</param>
        /// <param name="constraint">检查约束函数，并返回检查结果。</param>
        /// <returns>返回操作结果。</returns>
        public DeleteResult DeleteByKeyWithConstraint(TKey key, Func<TEntity, CheckResult> constraint = null)
        {
            var operateResult = new DeleteResult();
            if (((key is string) && Convert.ToString(key).IsNullOrWhiteSpace()) || key.Equals(default(TKey)))
            {
                operateResult.SetResult(DeleteResultOption.ArgumentError);
                return operateResult;
            }
            //
            var entity = GetByKey(key);
            if (entity.IsNull())
            {
                operateResult.SetResult(DeleteResultOption.NotFound);
                return operateResult;
            }
            //
            if (constraint != null)
            {
                var checkResult = constraint(entity);
                if (checkResult.Result != CheckResultOption.Pass)
                {
                    operateResult.SetResult(DeleteResultOption.Constraint, checkResult.Message);
                    return operateResult;
                }
            }
            //
            _entityRepository.Delete(entity);
            return operateResult;
        }

        #endregion

        #region 查询

        /// <summary>
        /// 是否存在符合指定筛选表达式的数据。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="key">排除的主键值。</param>
        /// <returns></returns>
        public virtual bool Exists(Expression<Func<TEntity, bool>> predicate, TKey key = default(TKey))
        {
            return _entityRepository.Exists(predicate, key);
        }

        /// <summary>
        /// 根据主键获取数据实体。
        /// </summary>
        /// <param name="key">主键。</param>
        /// <returns>如果检索到记录，则返回数据实体，否则返回null。</returns>
        public virtual TEntity GetByKey(TKey key)
        {
            return _entityRepository.GetByKey(key);
        }

        /// <summary>
        /// 获取第一个或默认的数据实体。
        /// </summary>
        /// <returns>如果检索到记录，则返回第一个数据实体，否则返回null。/returns>
        public virtual TEntity FirstOrDefault()
        {
            return _entityRepository.FirstOrDefault();
        }

        /// <summary>
        /// 根据指定筛选表达式获取第一个或默认的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns>如果检索到记录，则返回第一个数据实体，否则返回null。/returns>
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _entityRepository.FirstOrDefault(predicate);
        }

        /// <summary>
        /// 获取第一个或默认的数据实体。
        /// </summary>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns>如果检索到记录，则返回第一个数据实体，否则返回null。/returns>
        public virtual TEntity FirstOrDefault(params OrderSelector<TEntity>[] orderSelectors)
        {
            return _entityRepository.FirstOrDefault(orderSelectors);
        }

        /// <summary>
        /// 根据指定筛选表达式获取第一个或默认的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns>如果检索到记录，则返回第一个数据实体，否则返回null。/returns>
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors)
        {
            return _entityRepository.FirstOrDefault(predicate, orderSelectors);
        }

        /// <summary>
        /// 查询所有数据实体列表（非跟踪查询）。
        /// </summary>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public virtual List<TEntity> Query(params OrderSelector<TEntity>[] orderSelectors)
        {
            return _entityRepository.Query(orderSelectors);
        }

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（非跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        public virtual List<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return _entityRepository.Query(predicate);
        }

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（非跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public virtual List<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors)
        {
            return _entityRepository.Query(predicate, orderSelectors);
        }

        /// <summary>
        /// 查询所有数据实体列表（跟踪查询）。
        /// </summary>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public virtual List<TEntity> QueryTrack(params OrderSelector<TEntity>[] orderSelectors)
        {
            return _entityRepository.QueryTrack(orderSelectors);
        }

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        public virtual List<TEntity> QueryTrack(Expression<Func<TEntity, bool>> predicate)
        {
            return _entityRepository.QueryTrack(predicate);
        }

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public virtual List<TEntity> QueryTrack(Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors)
        {
            return _entityRepository.QueryTrack(predicate, orderSelectors);
        }

        #endregion

        #region 分页

        /// <summary>
        /// 分页列表。
        /// </summary>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <returns></returns>
        public virtual IPagedResult<TEntity> PagedList(int pageSize, int pageIndex)
        {
            return _entityRepository.PagedList(pageSize, pageIndex);
        }

        /// <summary>
        /// 分页列表。
        /// </summary>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public virtual IPagedResult<TEntity> PagedList(int pageSize, int pageIndex, params OrderSelector<TEntity>[] orderSelectors)
        {
            return _entityRepository.PagedList(pageSize, pageIndex, orderSelectors);
        }

        /// <summary>
        /// 分页列表。
        /// </summary>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        public virtual IPagedResult<TEntity> PagedList(int pageSize, int pageIndex, Expression<Func<TEntity, bool>> predicate)
        {
            return _entityRepository.PagedList(pageSize, pageIndex, predicate);
        }

        /// <summary>
        /// 分页列表。
        /// </summary>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public virtual IPagedResult<TEntity> PagedList(int pageSize, int pageIndex, Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors)
        {
            return _entityRepository.PagedList(pageSize, pageIndex, predicate, orderSelectors);
        }

        #endregion

        #region 函数

        /// <summary>
        /// 返回实体集合中满足条件的的元素数量。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _entityRepository.Count(predicate);
        }

        #endregion
    }
}
