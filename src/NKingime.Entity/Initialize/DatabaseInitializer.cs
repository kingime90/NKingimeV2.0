using System;
using NKingime.Core.Config;
using NKingime.Core.Initialize;

namespace NKingime.Entity.Initialize
{
    /// <summary>
    /// 数据库初始化。
    /// </summary>
    public class DatabaseInitializer : IDatabaseInitializer
    {
        /// <summary>
        /// 初始化数据库。
        /// </summary>
        /// <param name="contextConfigs">数据库上下文配置。</param>
        public void Initialize(params DbContextConfig[] contextConfigs)
        {
            
        }
    }
}
