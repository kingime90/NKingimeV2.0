using System;
using System.Linq;
using NKingime.Core.Option;
using NKingime.Core.Dependency;
using NKingime.Utility.Extensions;

namespace NKingime.Core.Extensions
{
    /// <summary>
    /// 依赖注入映射描述信息集合扩展方法。
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加实时模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        public static IServiceCollection AddTransient(this IServiceCollection collection, Type serviceType, Type implementationType)
        {
            return collection.TryAdd(ServiceDescriptor.Transient(serviceType, implementationType));
        }

        /// <summary>
        /// 添加实时模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        public static IServiceCollection AddTransient(this IServiceCollection collection, Type serviceType, object implementationInstance)
        {
            return collection.TryAdd(ServiceDescriptor.Transient(serviceType, implementationInstance));
        }

        /// <summary>
        /// 添加实时模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        public static IServiceCollection AddTransient(this IServiceCollection collection, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            return collection.TryAdd(ServiceDescriptor.Transient(serviceType, implementationFactory));
        }

        /// <summary>
        /// 添加实时模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection collection) where TService : class where TImplementation : TService
        {
            return collection.TryAdd(ServiceDescriptor.Transient<TService, TImplementation>());
        }

        /// <summary>
        /// 添加实时模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        public static IServiceCollection AddTransient<TService>(this IServiceCollection collection, object implementationInstance) where TService : class
        {
            return collection.TryAdd(ServiceDescriptor.Transient<TService>(implementationInstance));
        }

        /// <summary>
        /// 添加实时模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        public static IServiceCollection AddTransient<TService>(this IServiceCollection collection, Func<IServiceProvider, object> implementationFactory) where TService : class
        {
            return collection.TryAdd(ServiceDescriptor.Transient<TService>(implementationFactory));
        }

        /// <summary>
        /// 添加局部模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        public static IServiceCollection AddScope(this IServiceCollection collection, Type serviceType)
        {
            return collection.TryAdd(ServiceDescriptor.Scope(serviceType, serviceType));
        }

        /// <summary>
        /// 添加局部模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        public static IServiceCollection AddScope(this IServiceCollection collection, Type serviceType, Type implementationType)
        {
            return collection.TryAdd(ServiceDescriptor.Scope(serviceType, implementationType));
        }

        /// <summary>
        /// 添加局部模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        public static IServiceCollection AddScope(this IServiceCollection collection, Type serviceType, object implementationInstance)
        {
            return collection.TryAdd(ServiceDescriptor.Scope(serviceType, implementationInstance));
        }

        /// <summary>
        /// 添加局部模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        public static IServiceCollection AddScope(this IServiceCollection collection, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            return collection.TryAdd(ServiceDescriptor.Scope(serviceType, implementationFactory));
        }

        /// <summary>
        /// 添加局部模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        public static IServiceCollection AddScope<TService, TImplementation>(this IServiceCollection collection) where TService : class where TImplementation : TService
        {
            return collection.TryAdd(ServiceDescriptor.Scope<TService, TImplementation>());
        }

        /// <summary>
        /// 添加局部模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        public static IServiceCollection AddScope<TService>(this IServiceCollection collection, object implementationInstance) where TService : class
        {
            return collection.TryAdd(ServiceDescriptor.Scope<TService>(implementationInstance));
        }

        /// <summary>
        /// 添加局部模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        public static IServiceCollection AddScope<TService>(this IServiceCollection collection, Func<IServiceProvider, object> implementationFactory) where TService : class
        {
            return collection.TryAdd(ServiceDescriptor.Scope<TService>(implementationFactory));
        }

        /// <summary>
        /// 添加单例模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        public static IServiceCollection AddSingleton<TService>(this IServiceCollection collection, TService instance) where TService : class
        {
            return collection.TryAdd(ServiceDescriptor.Singleton<TService>(instance));
        }

        /// <summary>
        /// 添加单例模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        public static IServiceCollection AddSingleton(this IServiceCollection collection, Type serviceType, Type implementationType)
        {
            return collection.TryAdd(ServiceDescriptor.Singleton(serviceType, implementationType));
        }

        /// <summary>
        /// 添加单例模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        public static IServiceCollection AddSingleton(this IServiceCollection collection, Type serviceType, object implementationInstance)
        {
            return collection.TryAdd(ServiceDescriptor.Singleton(serviceType, implementationInstance));
        }

        /// <summary>
        /// 添加单例模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        public static IServiceCollection AddSingleton(this IServiceCollection collection, Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            return collection.TryAdd(ServiceDescriptor.Singleton(serviceType, implementationFactory));
        }

        /// <summary>
        /// 添加单例模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection collection) where TService : class where TImplementation : TService
        {
            return collection.TryAdd(ServiceDescriptor.Singleton<TService, TImplementation>());
        }

        /// <summary>
        /// 添加单例模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        public static IServiceCollection AddSingleton<TService>(this IServiceCollection collection, object implementationInstance) where TService : class
        {
            return collection.TryAdd(ServiceDescriptor.Singleton<TService>(implementationInstance));
        }

        /// <summary>
        /// 添加单例模式服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        public static IServiceCollection AddSingleton<TService>(this IServiceCollection collection, Func<IServiceProvider, object> implementationFactory) where TService : class
        {
            return collection.TryAdd(ServiceDescriptor.Singleton<TService>(implementationFactory));
        }

        /// <summary>
        /// 添加服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationType">服务实现类型。</param>
        /// <param name="lifetime">生命周期。</param>
        public static IServiceCollection Add(this IServiceCollection collection, Type serviceType, Type implementationType, LifetimeOption lifetime)
        {
            return collection.TryAdd(ServiceDescriptor.Descriptor(serviceType, implementationType, lifetime));
        }

        /// <summary>
        /// 添加服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        /// <param name="lifetime">生命周期。</param>
        public static IServiceCollection Add(this IServiceCollection collection, Type serviceType, object implementationInstance, LifetimeOption lifetime)
        {
            return collection.TryAdd(ServiceDescriptor.Descriptor(serviceType, implementationInstance, lifetime));
        }

        /// <summary>
        /// 添加服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="serviceType">服务类型。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <param name="lifetime">生命周期。</param>
        public static IServiceCollection Add(this IServiceCollection collection, Type serviceType, Func<IServiceProvider, object> implementationFactory, LifetimeOption lifetime)
        {
            return collection.TryAdd(ServiceDescriptor.Descriptor(serviceType, implementationFactory, lifetime));
        }

        /// <summary>
        /// 添加服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <typeparam name="TImplementation">泛型实现类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="lifetime">生命周期。</param>
        public static IServiceCollection Add<TService, TImplementation>(this IServiceCollection collection, LifetimeOption lifetime) where TService : class where TImplementation : TService
        {
            return collection.TryAdd(ServiceDescriptor.Descriptor<TService, TImplementation>(lifetime));
        }

        /// <summary>
        /// 添加服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationInstance">服务实现实例。</param>
        /// <param name="lifetime">生命周期。</param>
        public static IServiceCollection Add<TService>(this IServiceCollection collection, object implementationInstance, LifetimeOption lifetime) where TService : class
        {
            return collection.TryAdd(ServiceDescriptor.Descriptor<TService>(implementationInstance, lifetime));
        }

        /// <summary>
        /// 添加服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <typeparam name="TService">泛型服务类型。</typeparam>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="implementationFactory">服务实现实例工厂。</param>
        /// <param name="lifetime">生命周期。</param>
        public static IServiceCollection Add<TService>(this IServiceCollection collection, Func<IServiceProvider, object> implementationFactory, LifetimeOption lifetime) where TService : class
        {
            return collection.TryAdd(ServiceDescriptor.Descriptor<TService>(implementationFactory, lifetime));
        }

        /// <summary>
        /// 尝试添加服务映射信息到服务映射信息集合中。
        /// </summary>
        /// <param name="collection">服务映射信息集合。</param>
        /// <param name="descriptor">服务映射信息。</param>
        public static IServiceCollection TryAdd(this IServiceCollection collection, ServiceDescriptor descriptor)
        {
            var service = collection.FirstOrDefault(p => p.ServiceType == descriptor.ServiceType && p.ImplementationType == descriptor.ImplementationType);
            if (service.IsNotNull())
            {
                collection.Remove(service);
            }
            collection.Add(descriptor);
            return collection;
        }
    }
}
