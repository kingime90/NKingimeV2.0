using System;
using NKingime.Utility.General;

namespace NKingime.Validate
{
    /// <summary>
    /// 定义类型验证接口。
    /// </summary>
    public interface ITypeValid
    {
        /// <summary>
        /// 全球化资源。
        /// </summary>
        I18nResourceBase I18nResource { get; }

        /// <summary>
        /// 验证值是否满足规则。
        /// </summary>
        /// <param name="value">需要验证的值。</param>
        /// <param name="name">需要验证的值的名称。</param>
        /// <param name="description">需要验证的值的描述。</param>
        /// <param name="root">需要验证的值的根对象，如果没有，则为 null。</param>
        /// <returns></returns>
        ValidResult Validate(object value, string name, string description, object root = null);
    }
}
