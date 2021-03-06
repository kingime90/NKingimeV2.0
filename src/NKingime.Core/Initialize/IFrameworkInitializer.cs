﻿using NKingime.Core.Dependency;

namespace NKingime.Core.Initialize
{
    /// <summary>
    /// 定义框架初始化器。
    /// </summary>
    public interface IFrameworkInitializer
    {
        /// <summary>
        /// 开始执行框架初始化。
        /// </summary>
        /// <param name="iocBuilder">依赖注入构建器。</param>
        void Initialize(IIocBuilder iocBuilder);
    }
}