﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using NKingime.Core.Entity;
using NKingime.Utility.General;
using NKingime.Utility.Extensions;
using NKingime.Utility;

namespace NKingime.Core.Data
{
    /// <summary>
    /// 数据仓储泛型接口基类。
    /// </summary>
    /// <typeparam name="TEntity">数据实体类型。</typeparam>
    /// <typeparam name="TKey">主键类型。</typeparam>
    public abstract class RepositoryBase<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : IEquatable<TKey>
    {
        #region 属性

        /// <summary>
        /// 获取当前业务单元操作。
        /// </summary>
        public abstract IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// 获取 当前数据实体类型的查询数据集，数据将使用不跟踪变化的方式来查询，当数据用于展现时，推荐使用此数据集，如果用于新增，更新，删除时，请使用<see cref="TrackEntities"/>数据集。
        /// </summary>
        public abstract IQueryable<TEntity> Entities { get; }

        /// <summary>
        /// 获取 当前数据实体类型的查询数据集，当数据用于新增，更新，删除时，使用此数据集，如果数据用于展现，推荐使用<see cref="Entities"/>数据集。
        /// </summary>
        public abstract IQueryable<TEntity> TrackEntities { get; }

        #endregion

        #region 新增

        /// <summary>
        /// 保存数据实体。
        /// </summary>
        /// <param name="entity">数据实体。</param>
        /// <returns>返回受影响的行数。</returns>
        public abstract int Save(TEntity entity);

        /// <summary>
        /// 保存数据实体序列。
        /// </summary>
        /// <param name="entities">数据实体序列。</param>
        /// <returns>返回受影响的行数。</returns>
        public abstract int Save(IEnumerable<TEntity> entities);

        #endregion

        #region 删除

        /// <summary>
        /// 根据主键删除数据实体。
        /// </summary>
        /// <param name="key">主键。</param>
        /// <returns>返回受影响的行数。</returns>
        public abstract int DeleteByKey(TKey key);

        /// <summary>
        /// 删除数据实体。
        /// </summary>
        /// <param name="entity">数据实体。</param>
        /// <returns>返回受影响的行数。</returns>
        public abstract int Delete(TEntity entity);

        /// <summary>
        /// 删除数据实体序列。
        /// </summary>
        /// <param name="entities">数据实体序列。</param>
        /// <returns>返回受影响的行数。</returns>
        public abstract int Delete(IEnumerable<TEntity> entities);

        /// <summary>
        /// 删除所有符合条件的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns>返回受影响的行数。</returns>
        public abstract int Delete(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region 更新

        /// <summary>
        /// 更新数据实体。
        /// </summary>
        /// <param name="entity">数据实体。</param>
        /// <returns>返回受影响的行数。</returns>
        public abstract int Update(TEntity entity);

        /// <summary>
        /// 更新数据实体序列。
        /// </summary>
        /// <param name="entities">数据实体序列。</param>
        /// <returns>返回受影响的行数。</returns>
        public abstract int Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// 更新所有符合条件的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="updateExpression">更新实体表达式。</param>
        /// <returns></returns>
        public abstract int Update(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateExpression);

        /// <summary>
        /// 根据主键逻辑删除数据实体。
        /// </summary>
        /// <param name="key">主键。</param>
        /// <returns>返回受影响的行数。</returns>
        public virtual int RecycleByKey(TKey key)
        {
            TEntity entity = GetByKey(key);
            return entity.IsNull() ? 0 : Recycle(entity);
        }

        /// <summary>
        /// 逻辑删除数据实体。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Recycle(TEntity entity)
        {
            RecycleEntity(entity);
            return Update(entity);
        }

        /// <summary>
        /// 逻辑删除数据序列。
        /// </summary>
        /// <param name="entities">数据实体序列。</param>
        /// <returns>返回受影响的行数。</returns>
        public virtual int Recycle(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                RecycleEntity(entity);
            }
            return Update(entities);
        }

        /// <summary>
        /// 逻辑删除所有符合条件的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns>返回受影响的行数。</returns>
        public virtual int Recycle(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = QueryTrack(predicate);
            return entities.IsEmpty() ? 0 : Recycle(entities);
        }

        /// <summary>
        /// 根据主键逻辑还原数据实体。
        /// </summary>
        /// <param name="key">主键。</param>
        /// <returns>返回受影响的行数。</returns>
        public virtual int RestoreByKey(TKey key)
        {
            TEntity entity = GetByKey(key);
            return entity.IsNull() ? 0 : Restore(entity);
        }

        /// <summary>
        /// 逻辑还原数据实体。
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Restore(TEntity entity)
        {
            RestoreEntity(entity);
            return Update(entity);
        }

        /// <summary>
        /// 逻辑还原数据实体序列。
        /// </summary>
        /// <param name="entities">数据实体序列。</param>
        /// <returns>返回受影响的行数。</returns>
        public virtual int Restore(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                RestoreEntity(entity);
            }
            return Update(entities);
        }

        /// <summary>
        /// 逻辑还原所有符合条件的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns>返回受影响的行数。</returns>
        public virtual int Restore(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = QueryTrack(predicate);
            return entities.IsEmpty() ? 0 : Restore(entities);
        }

        #endregion

        #region 查询

        /// <summary>
        /// 是否存在符合指定筛选表达式的数据。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="key">排除的主键值。</param>
        /// <returns></returns>
        public abstract bool Exists(Expression<Func<TEntity, bool>> predicate, TKey key = default(TKey));

        /// <summary>
        /// 根据主键获取数据实体。
        /// </summary>
        /// <param name="key">主键。</param>
        /// <returns>如果检索到记录，则返回数据实体，否则返回null。</returns>
        public abstract TEntity GetByKey(TKey key);

        /// <summary>
        /// 获取第一个或默认的数据实体。
        /// </summary>
        /// <returns>如果检索到记录，则返回第一个数据实体，否则返回null。/returns>
        public virtual TEntity FirstOrDefault()
        {
            return FirstOrDefault((Expression<Func<TEntity, bool>>)null);
        }

        /// <summary>
        /// 根据指定筛选表达式获取第一个或默认的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns>如果检索到记录，则返回第一个数据实体，否则返回null。/returns>
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return FirstOrDefault(predicate, null);
        }

        /// <summary>
        /// 获取第一个或默认的数据实体。
        /// </summary>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns>如果检索到记录，则返回第一个数据实体，否则返回null。/returns>
        public virtual TEntity FirstOrDefault(params OrderSelector<TEntity>[] orderSelectors)
        {
            return FirstOrDefault(null, orderSelectors);
        }

        /// <summary>
        /// 根据指定筛选表达式获取第一个或默认的数据实体。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns>如果检索到记录，则返回第一个数据实体，否则返回null。/returns>
        public abstract TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors);

        /// <summary>
        /// 查询所有数据实体列表（非跟踪查询）。
        /// </summary>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public virtual List<TEntity> Query(params OrderSelector<TEntity>[] orderSelectors)
        {
            return Query(null, orderSelectors);
        }

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（非跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        public virtual List<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return Query(predicate, null);
        }

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（非跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public abstract List<TEntity> Query(Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors);

        /// <summary>
        /// 查询所有数据实体列表（跟踪查询）。
        /// </summary>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public virtual List<TEntity> QueryTrack(params OrderSelector<TEntity>[] orderSelectors)
        {
            return QueryTrack(null, orderSelectors);
        }

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        public virtual List<TEntity> QueryTrack(Expression<Func<TEntity, bool>> predicate)
        {
            return QueryTrack(predicate, null);
        }

        /// <summary>
        /// 根据指定筛选表达式获取数据实体列表（跟踪查询）。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public abstract List<TEntity> QueryTrack(Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors);

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
            return PagedList(pageSize, pageIndex, null, (OrderSelector<TEntity>[])null);
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
            return PagedList(pageSize, pageIndex, null, orderSelectors);
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
            return PagedList(pageSize, pageIndex, predicate, null);
        }

        /// <summary>
        /// 分页列表。
        /// </summary>
        /// <param name="pageSize">每页多少条。</param>
        /// <param name="pageIndex">页码。</param>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <param name="orderSelectors">排序选择器数组。</param>
        /// <returns></returns>
        public abstract IPagedResult<TEntity> PagedList(int pageSize, int pageIndex, Expression<Func<TEntity, bool>> predicate, params OrderSelector<TEntity>[] orderSelectors);

        #endregion

        #region 函数

        /// <summary>
        /// 返回实体集合中满足条件的的元素数量。
        /// </summary>
        /// <param name="predicate">基于谓词筛选表达式。</param>
        /// <returns></returns>
        public abstract int Count(Expression<Func<TEntity, bool>> predicate);

        #endregion

        #region 辅助方法

        /// <summary>
        /// 检查创建时间，如果实现创建时间数据实体接口，则更新创建时间。
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="createTime"></param>
        protected virtual void CheckCreateTime(TEntity entity, DateTime createTime)
        {
            entity.SetPropertyValue<TEntity, ICreateTime, DateTime>(s => s.CreateTime, createTime);
        }

        /// <summary>
        /// 检查主键。
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void CheckPrimaryKey(TEntity entity)
        {
            var guidIdentity = (entity as GuidIdentity);
            if (guidIdentity.IsNotNull())
            {
                guidIdentity.Id = IdentityUtil.NewGuid();
                return;
            }
            //
            var hexIdentity = (entity as HexIdentity);
            if (hexIdentity.IsNotNull())
            {
                hexIdentity.Id = IdentityUtil.NewHex();
                return;
            }
            //
            var uuidIdentity = (entity as UUIDIdentity);
            if (uuidIdentity.IsNotNull())
            {
                uuidIdentity.Id = IdentityUtil.NewUUID();
                return;
            }
        }

        /// <summary>
        /// 检查逻辑删除，如果实现逻辑删除数据实体接口，则更新是否已删除。
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isDeleted"></param>
        private void CheckRecyclable(TEntity entity, bool isDeleted)
        {
            entity.SetPropertyValue<TEntity, IRecyclable, bool>(s => s.IsDeleted, isDeleted);
        }

        /// <summary>
        /// 逻辑删除数据实体。
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void RecycleEntity(TEntity entity)
        {
            CheckRecyclable(entity, true);
        }

        /// <summary>
        /// 逻辑还原数据实体。
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void RestoreEntity(TEntity entity)
        {
            CheckRecyclable(entity, false);
        }

        #endregion
    }
}
