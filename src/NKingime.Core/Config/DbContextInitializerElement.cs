using System;
using System.Configuration;

namespace NKingime.Core.Config
{
    /// <summary>
    /// 数据库上下文初始化配置元素。
    /// </summary>
    public class DbContextInitializerElement : ConfigurationElement
    {
        private const string TypeKey = "type";

        private const string MappersKey = "mappers";

        private const string ProfilesKey = "profiles";

        /// <summary>
        /// 获取或设置 数据库上下文初始化类型名称。
        /// </summary>
        [ConfigurationProperty(TypeKey)]
        public string InitializerTypeName
        {
            get { return Convert.ToString(this[TypeKey]); }
            set { this[TypeKey] = value; }
        }

        /// <summary>
        /// 获取或设置 数据实体映射程序集名称（可包含多个，“,”号分割）。
        /// </summary>
        [ConfigurationProperty(MappersKey)]
        public string MapperAssemblys
        {
            get { return Convert.ToString(this[MappersKey]); }
            set { this[MappersKey] = value; }
        }

        /// <summary>
        /// 获取或设置 数据实体DTO映射配置程序集名称（可包含多个，“,”号分割）。
        /// </summary>
        [ConfigurationProperty(ProfilesKey)]
        public string ProfileAssemblys
        {
            get { return Convert.ToString(this[ProfilesKey]); }
            set { this[ProfilesKey] = value; }
        }
    }
}