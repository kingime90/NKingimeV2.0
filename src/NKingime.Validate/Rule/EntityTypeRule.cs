using System;

namespace NKingime.Validate
{
    /// <summary>
    /// 实体类型验证规则。
    /// </summary>
    /// <typeparam name="T">实体类型。</typeparam>
    public class EntityTypeRule<T> : ValidRule where T : class
    {
        /// <summary>
        /// 初始化一个<see cref="EntityTypeRule"/>类型的新实例。
        /// </summary>
        /// <param name="isRequired"></param>
        public EntityTypeRule(bool isRequired = false) : base(isRequired)
        {

        }
    }
}
