using System;

namespace NKingime.Validate
{
    /// <summary>
    /// 定义类型验证接口。
    /// </summary>
    public interface ITypeValid
    {
        /// <summary>
        /// 验证数据是否满足规则。
        /// </summary>
        /// <param name="value">需要验证的值。</param>
        /// <param name="root">需要验证的根对象，如果没有，则为 null。</param>
        /// <returns></returns>
        ValidResult Validate(object value, object root = null);
    }
}
