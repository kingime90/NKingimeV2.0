using System;
using System.Linq;
using NKingime.Core.Data;
using NKingime.Core.Config;
using NKingime.Core.Dependency;
using NKingime.Core.Extensions;

namespace NKingime.Entity.Extensions
{
    /// <summary>
    /// 服务映射信息集合扩展方法。
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加数据相关服务映射信息。
        /// </summary>
        /// <param name="services">服务映射信息集合。</param>
        public static void AddDataServices(this IServiceCollection services)
        {
            ContextConfig contextConfig = ContextConfig.Instance;
            Type[] contextTypes = contextConfig.DbContexts.Where(m => m.Enabled).Select(m => m.ContextType).ToArray();
            Type baseType = typeof(IUnitOfWork);
            foreach (var contextType in contextTypes)
            {
                if (!baseType.IsAssignableFrom(contextType))
                {

                }
                services.AddScope(baseType, contextType);
                services.AddScope(contextType);
            }
        }
    }
}
