using System;

namespace NKingime.Validate
{
    /// <summary>
    /// 定义实体类型验证接口。
    /// </summary>
    /// <typeparam name="T">实体类型。</typeparam>
    public interface IEntityTypeValid<T> where T : class
    {
        /// <summary>
        /// 设置是否必填，默认必填。
        /// </summary>
        /// <param name="isRequired">是否必填。</param>
        /// <returns></returns>
        IEntityTypeValid<T> Required(bool isRequired = true);
    }
}
