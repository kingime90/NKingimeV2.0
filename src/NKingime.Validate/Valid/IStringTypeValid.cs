using System;

namespace NKingime.Validate
{
    /// <summary>
    /// 定义字符串类型验证接口。
    /// </summary>
    public interface IStringTypeValid : ITypeValid
    {
        /// <summary>
        /// 设置是否必填，默认必填。
        /// </summary>
        /// <param name="isRequired">是否必填。</param>
        /// <returns></returns>
        IStringTypeValid Required(bool isRequired = true);
    }
}
