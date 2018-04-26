using System;
using System.Linq;
using System.Reflection;

namespace NKingime.Core.Reflection
{
    /// <summary>
    /// <see cref="{TDependency}"/>接口实现类查找器。
    /// </summary>
    /// <typeparam name="TDependency">依赖注入类型。</typeparam>
    public abstract class TypeFinderBase<TDependency> : FinderBase<Type>, ITypeFinder
    {
        /// <summary>
        /// 初始化一个<see cref="TypeFinderBase"/>类型的新实例。
        /// </summary>
        public TypeFinderBase()
        {
            AssemblyFinder = new DirectoryAssemblyFinder();
        }

        /// <summary>
        /// 获取或设置 程序集查找器。
        /// </summary>
        public virtual IAllAssemblyFinder AssemblyFinder { get; set; }

        /// <summary>
        /// 查找所有项。
        /// </summary>
        /// <returns></returns>
        public override Type[] FindAll()
        {
            Assembly[] assemblies = AssemblyFinder.FindAll();
            var dependencyType = typeof(TDependency);
            return assemblies.SelectMany(assembly => assembly.GetTypes().Where(type => dependencyType.IsAssignableFrom(type))).Distinct().ToArray();
        }
    }
}
