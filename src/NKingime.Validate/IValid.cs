using System;
using System.Linq.Expressions;

namespace NKingime.Validate
{
    /// <summary>
    ///  定义实体验证接口。
    /// </summary>
    /// <typeparam name="TEntity">实体类型。</typeparam>
    public interface IValid<TEntity> where TEntity : class
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

        /// <summary>
        /// 验证实体是否满足规则。
        /// </summary>
        /// <param name="entity">实体实例。</param>
        /// <returns></returns>
        ValidResult Validate(TEntity entity);
    }
}
