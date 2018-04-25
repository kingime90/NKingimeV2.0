using System;
using System.Linq;
using NKingime.Core.Option;
using NKingime.Core.Extensions;
using NKingime.Utility.Extensions;

namespace NKingime.Core.Dependency
{
    /// <summary>
    /// 服务构建器。
    /// </summary>
    public class ServiceBuilder : IServiceBuilder
    {
        private readonly ServiceBuildOptions _options;

        /// <summary>
        /// 初始化一个<see cref="ServiceBuilder"/>类型的新实例
        /// </summary>
        public ServiceBuilder()
            : this(new ServiceBuildOptions())
        { }

        /// <summary>
        /// 初始化一个<see cref="ServiceBuilder"/>类型的新实例
        /// </summary>
        public ServiceBuilder(ServiceBuildOptions options)
        {
            _options = options;
            ExceptInterfaceTypes = new Type[]
            {
                typeof(IDisposable),
                typeof(IDependency),
                typeof(ITransientDependency),
                typeof(IScopeDependency),
                typeof(ISingletonDependency),
            };
        }

        /// <summary>
        /// 排除的接口类型数组。
        /// </summary>
        public Type[] ExceptInterfaceTypes { get; private set; }

        /// <summary>
        /// 构建。
        /// </summary>
        /// <returns></returns>
        public IServiceCollection Build()
        {
            IServiceCollection services = new ServiceCollection();
            ServiceBuildOptions options = _options;

            var implementationTypes = options.TransientTypeFinder.FindAll();
            AddTypeWithInterfaces(services, implementationTypes, LifetimeOption.Transient);

            implementationTypes = options.ScopeTypeFinder.FindAll();
            AddTypeWithInterfaces(services, implementationTypes, LifetimeOption.Scope);

            implementationTypes = options.SingletonTypeFinder.FindAll();
            AddTypeWithInterfaces(services, implementationTypes, LifetimeOption.Singleton);

            return services;
        }

        /// <summary>
        /// 添加依赖注入映射描述信息。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationTypes">服务实现类型序列。</param>
        /// <param name="lifetime">生命周期。</param>
        protected void AddTypeWithInterfaces(IServiceCollection collection, Type[] implementationTypes, LifetimeOption lifetime)
        {
            Type[] interfaceTypes;
            foreach (var implementationType in implementationTypes)
            {
                if (implementationType.IsAbstract || implementationType.IsInterface)
                {
                    continue;
                }
                //
                interfaceTypes = GetImplementedInterfaces(implementationType);
                if (interfaceTypes.Length == 0)
                {
                    collection.Add(implementationType, implementationType, lifetime);
                    continue;
                }
                foreach (var interfaceType in interfaceTypes)
                {
                    collection.Add(interfaceType, implementationType, lifetime);
                }
            }
        }

        /// <summary>
        /// 获取指定类型实现或继承的接口数组。
        /// </summary>
        /// <param name="implementationType">服务实现类型。</param>
        /// <returns></returns>
        protected Type[] GetImplementedInterfaces(Type implementationType)
        {
            var interfaceTypes = implementationType.GetInterfaces().Where(p => !ExceptInterfaceTypes.Contains(p)).ToArray();
            int length = interfaceTypes.Length;
            Type interfaceType;
            for (int i = 0; i < length; i++)
            {
                interfaceType = interfaceTypes[i];
                if (interfaceType.IsGenericType && !interfaceType.IsGenericTypeDefinition && interfaceType.FullName.IsNull())
                {
                    interfaceTypes[i] = interfaceType.GetGenericTypeDefinition();
                }
            }
            return interfaceTypes;
        }
    }
}
