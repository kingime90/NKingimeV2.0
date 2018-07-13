using System;
using System.Linq.Expressions;

namespace NKingime.Validate
{
    /// <summary>
    ///  定义简单实体验证接口。
    /// </summary>
    /// <typeparam name="TEntity">实体接口类型。</typeparam>
    public interface ISimpleValid<TEntity> : IValid where TEntity : class, IEntity
    {
        /// <summary>
        /// 字符串类型验证。
        /// </summary>
        /// <param name="propertySelector">选择字符串类型属性函数。</param>
        /// <returns></returns>
        IStringTypeValid StringType(Expression<Func<TEntity, string>> propertySelector);

        /// <summary>
        /// 值类型验证。
        /// </summary>
        /// <typeparam name="TProperty">值类型。</typeparam>
        /// <param name="propertySelector">选择值类型属性函数。</param>
        /// <returns></returns>
        IValueTypeValid<TProperty> ValueType<TProperty>(Expression<Func<TEntity, TProperty>> propertySelector) where TProperty : struct, IComparable;

        /// <summary>
        /// 可空值类型验证。
        /// </summary>
        /// <typeparam name="TProperty">值类型。</typeparam>
        /// <param name="propertySelector">选择可空值类型属性函数。</param>
        /// <returns></returns>
        INullableTypeValid<TProperty> NullableType<TProperty>(Expression<Func<TEntity, TProperty?>> propertySelector) where TProperty : struct, IComparable;
    }
}
