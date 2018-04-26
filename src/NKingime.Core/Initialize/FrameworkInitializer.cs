using System;
using System.Linq;
using NKingime.Core.Config;
using NKingime.Core.Dependency;

namespace NKingime.Core.Initialize
{
    /// <summary>
    /// 框架初始化器。
    /// </summary>
    public class FrameworkInitializer : IFrameworkInitializer
    {
        //基础模块，只初始化一次
        private static bool _databaseInitialized;

        /// <summary>
        /// 开始执行框架初始化。
        /// </summary>
        /// <param name="iocBuilder">依赖注入构建器。</param>
        public void Initialize(IIocBuilder iocBuilder)
        {
            //依赖注入初始化
            IServiceProvider provider = iocBuilder.Build();

            ContextConfig contextConfig = ContextConfig.Instance;
            //数据库初始化
            IDatabaseInitializer databaseInitializer = provider.GetService<IDatabaseInitializer>();
            if (!_databaseInitialized && databaseInitializer != null)
            {
                databaseInitializer.Initialize(contextConfig.DbContexts.ToArray());
                _databaseInitialized = true;
            }
        }
    }
}
