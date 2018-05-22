using System;
using AutoMapper;

namespace NKingime.Core.Dto
{
    /// <summary>
    /// 数据实体DTO映射配置。 
    /// </summary>
    /// <typeparam name="TEntityDto">实体DTO类型。</typeparam>
    /// <typeparam name="TEntity">实体类型。</typeparam>
    public abstract class EntityDtoProfile<TEntityDto, TEntity> : Profile where TEntityDto : class, IEntityDto where TEntity : class
    {
        /// <summary>
        /// 初始化一个<see cref="EntityDtoProfile{TEntityDto,TEntity}"/>成功实例。
        /// </summary>
        public EntityDtoProfile()
        {
            var expression = CreateMap<TEntityDto, TEntity>();
            Configure(expression);
        }

        /// <summary>
        /// 配置。
        /// </summary>
        /// <param name="expression"></param>
        public virtual void Configure(IMappingExpression<TEntityDto, TEntity> expression)
        {

        }
    }
}
