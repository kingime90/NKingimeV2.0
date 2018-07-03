using System;

namespace NKingime.Validate
{
    /// <summary>
    ///  复合实体验证。
    /// </summary>
    /// <typeparam name="TEntity">实体接口类型。</typeparam>
    public class CompoundValid<TEntity> : SimpleValid<TEntity>, ICompoundValid<TEntity> where TEntity : IEntity
    {
        public void EntityType<TProperty>(System.Linq.Expressions.Expression<Func<TEntity, TProperty>> propertySelector, IValid<TProperty> valid) where TProperty : IEntity
        {
            throw new NotImplementedException();
        }
    }
}
