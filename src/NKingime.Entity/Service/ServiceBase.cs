using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NKingime.Core.Dto;
using NKingime.Core.Data;
using NKingime.Core.Entity;
using NKingime.Core.Option;
using NKingime.Core.Service;
using NKingime.Utility.General;
using NKingime.Utility.Extensions;
using NKingime.Core.Extensions;

namespace NKingime.Entity.Service
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
        /// 初始化一个<see cref="ServiceBase{TEntity,TKey}"/>类型的新实例。
        /// </summary>
        /// <param name="entityRepository"></param>
        public ServiceBase(IRepository<TEntity, TKey> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        #region 保存

        /// <summary>
        /// 保存数据实体并校验。
        /// </summary>
        /// <typeparam name="TEntityDto">数据实体DTO类型。</typeparam>
        /// <param name="entityDto">数据实体DTO实例。</param>
        /// <param name="check">校验函数 (<see cref="TEntity"/> detached) => { return <see cref="new CheckResult(CheckResultOption.Pass)"/>; }，其中 detached 该实体未由上下文跟踪；并返回校验消息结果。</param>
        /// <returns>返回保存消息结果。</returns>
        public SaveResult SaveWithCheck<TEntityDto>(TEntityDto entityDto, Func<TEntity, CheckResult> check = null) where TEntityDto : class, IEntityDto, IEntity<TKey>
        {
            var operateResult = new SaveResult();
            if (entityDto == null)
            {
                operateResult.SetResult(SaveResultOption.ArgumentError);
                return operateResult;
            }
            //该实体未由上下文跟踪（分离的）
            var detached = entityDto.MapTo<TEntity>();
            if (check != null)
            {
                var checkResult = check(detached);
                if (checkResult.Result != CheckResultOption.Pass)
                {
                    operateResult.SetResult(SaveResultOption.Constraint, checkResult.Message);
                    return operateResult;
                }
            }
            _entityRepository.Save(detached);
            //
            return operateResult;
        }

        #endregion

        #region 删除

        /// <summary>
        /// 根据主键删除数据实体并校验。
        /// </summary>
        /// <param name="key">主键。</param>
        /// <param name="check">校验函数，并返回校验消息结果。</param>
        /// <returns>返回删除消息结果。</returns>
        public DeleteResult DeleteByKeyWithCheck(TKey key, Func<TEntity, CheckResult> check = null)
        {
            var operateResult = new DeleteResult();
            if (key.Equals(default(TKey)) || ((key is string) && Convert.ToString(key).IsNullOrWhiteSpace()))
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
            if (check != null)
            {
                var checkResult = check(entity);
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

        #region 更新

        /// <summary>
        /// 更新数据实体并校验。
        /// </summary>
        /// <typeparam name="TEntityDto">数据实体DTO类型。</typeparam>
        /// <param name="entityDto">数据实体DTO实例。</param>
        /// <param name="check">校验函数 (<see cref="TEntity"/> unchanged, <see cref="TEntity"/> modified) => { return <see cref="new CheckResult(CheckResultOption.Pass)"/>; }，其中 unchanged 数据库中未更改的数据，modified 已修改其中的一些或所有属性值；并返回校验消息结果。</param>
        /// <returns>返回更新消息结果。</returns>
        public UpdateResult UpdateWithCheck<TEntityDto>(TEntityDto entityDto, Func<TEntity, TEntity, CheckResult> check = null) where TEntityDto : class, IEntityDto, IEntity<TKey>
        {
            var operateResult = new UpdateResult();
            if (entityDto == null || entityDto.Id.Equals(default(TKey)) || ((entityDto.Id is string) && Convert.ToString(entityDto.Id).IsNullOrWhiteSpace()))
            {
                operateResult.SetResult(UpdateResultOption.ArgumentError);
                return operateResult;
            }
            var entity = GetByKey(entityDto.Id);
            if (entity.IsNull())
            {
                operateResult.SetResult(UpdateResultOption.NotFound);
                return operateResult;
            }
            //实体将由上下文跟踪并存在于数据库中，其属性值与数据库中的值相同
            var unchanged = entity.Clone() as TEntity;
            //实体将由上下文跟踪并存在于数据库中，已修改其中的一些或所有属性值
            entity = entityDto.MapTo(entity);
            if (check != null)
            {
                var checkResult = check(unchanged, entity);
                if (checkResult.Result != CheckResultOption.Pass)
                {
                    operateResult.SetResult(UpdateResultOption.Constraint, checkResult.Message);
                    return operateResult;
                }
            }
            _entityRepository.Update(entity);
            //
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
