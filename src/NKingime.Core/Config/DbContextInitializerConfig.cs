using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using NKingime.Core.Reflection;
using NKingime.Utility.Extensions;

namespace NKingime.Core.Config
{
    /// <summary>
    /// 数据库上下文初始化配置。
    /// </summary>
    public class DbContextInitializerConfig
    {
        /// <summary>
        /// 初始化一个<see cref="DbContextInitializerConfig"/>类型的新实例。
        /// </summary>
        private DbContextInitializerConfig()
        {
            AssemblyFinder = new DirectoryAssemblyFinder();
            _mapperAssemblys = new List<Assembly>();
            _profileAssemblys = new List<Assembly>();
        }

        /// <summary>
        /// 初始化一个<see cref="DbContextInitializerConfig"/>类型的新实例。
        /// </summary>
        /// <param name="element"></param>
        public DbContextInitializerConfig(DbContextInitializerElement element) : this()
        {
            InitializerType = Type.GetType(element.InitializerTypeName);
            if (InitializerType.IsNull())
            {
                //异常处理
            }
            //
            var mapperAssemblyNames = element.MapperAssemblys.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var assemblySet = AssemblyFinder.FindAll().ToDictionary(assembly => assembly.GetName().Name);
            foreach (var assemblyName in mapperAssemblyNames)
            {
                if (!assemblySet.ContainsKey(assemblyName))
                {
                    //异常处理
                }
                _mapperAssemblys.Add(assemblySet[assemblyName]);
            }
            //
            var profileAssemblyNames = element.ProfileAssemblys.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var assemblyName in profileAssemblyNames)
            {
                if (!assemblySet.ContainsKey(assemblyName))
                {
                    //异常处理
                }
                _profileAssemblys.Add(assemblySet[assemblyName]);
            }
        }

        /// <summary>
        /// 获取 初始化类型。
        /// </summary>
        public Type InitializerType { get; }

        private readonly List<Assembly> _mapperAssemblys;

        /// <summary>
        /// 获取 数据实体映射程序集序列。
        /// </summary>
        public IEnumerable<Assembly> MapperAssemblys
        {
            get
            {
                return _mapperAssemblys;
            }
        }

        private readonly List<Assembly> _profileAssemblys;

        /// <summary>
        /// 获取 数据实体DTO映射配置程序集序列。
        /// </summary>
        public IEnumerable<Assembly> ProfileAssemblys
        {
            get
            {
                return _profileAssemblys;
            }
        }

        /// <summary>
        /// 获取 程序集查找器。
        /// </summary>
        protected IAssemblyFinder AssemblyFinder { get; }
    }
}
