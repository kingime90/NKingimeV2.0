using System;
using NKingime.Core.Dto;

namespace NKingime.Core.Extensions
{
    /// <summary>
    /// AutoMapper扩展方法。
    /// </summary>
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// 映射到指定的目标类型。
        /// </summary>
        /// <typeparam name="TTarget">指定的目标类型。</typeparam>
        /// <param name="source">实体DTO接口实例。</param>
        /// <returns></returns>
        public static TTarget MapTo<TTarget>(this IEntityDto source) where TTarget : class
        {
            return AutoMapper.Mapper.Map<TTarget>(source);
        }

        /// <summary>
        /// 映射到指定的目标类型。
        /// </summary>
        /// <typeparam name="TSource">source 类型。</typeparam>
        /// <typeparam name="TTarget">指定的目标类型。</typeparam>
        /// <param name="source">source 类型实例。</param>
        /// <param name="target">指定的目标类型的实例。</param>
        /// <returns></returns>
        public static TTarget MapTo<TSource, TTarget>(this TSource source, TTarget target) where TSource : class, IEntityDto where TTarget : class
        {
            return AutoMapper.Mapper.Map(source, target);
        }
    }
}
