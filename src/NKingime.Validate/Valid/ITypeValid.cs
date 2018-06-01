using System;

namespace NKingime.Validate
{
    /// <summary>
    /// 定义类型验证接口。
    /// </summary>
    public interface ITypeValid
    {
        /// <summary>
        /// 获取 验证规则。
        /// </summary>
        ValidRule ValidRule { get; }

        /// <summary>
        /// 验证数据是否满足规则。
        /// </summary>
        /// <param name="value">值。</param>
        /// <returns></returns>
        ValidResult Validate(object value);
    }
}
