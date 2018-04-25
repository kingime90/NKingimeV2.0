using System;

namespace NKingime.Core.Dependency
{
    /// <summary>
    /// 定义服务构建器接口。
    /// </summary>
    public interface IServiceBuilder
    {
        /// <summary>
        /// 构建。
        /// </summary>
        /// <returns></returns>
        IServiceCollection Build();
    }
}
