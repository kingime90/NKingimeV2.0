using System;

namespace NKingime.Validate
{
    /// <summary>
    /// 定义验证接口。
    /// </summary>
    public interface IValid
    {
        /// <summary>
        /// 验证指定的值是否满足规则。
        /// </summary>
        /// <param name="entity">需要验证的值。</param>
        /// <returns></returns>
        ValidResult Validate(object value);
    }
}
