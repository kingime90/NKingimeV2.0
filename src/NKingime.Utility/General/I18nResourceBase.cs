using System;
using System.Resources;
using System.Threading;
using System.Reflection;
using System.Globalization;
using NKingime.Utility.Extensions;

namespace NKingime.Utility.General
{
    /// <summary>
    /// 全球化资源基类。
    /// </summary>
    public abstract class I18nResourceBase
    {
        /// <summary>
        /// 资源类型。
        /// </summary>
        public virtual Type ResourceType
        {
            get
            {
                return this.GetType();
            }
        }

        /// <summary>
        /// 资源程序集。
        /// </summary>
        public virtual Assembly ResourceAssembly
        {
            get
            {
                return ResourceType.Assembly;
            }
        }

        /// <summary>
        /// 资源名称。
        /// </summary>
        public virtual string ResourceName
        {
            get
            {
                return ResourceType.Name.RemoveEnd("Resource");
            }
        }

        /// <summary>
        /// 获取或设置当前区域性。
        /// </summary>
        public virtual CultureInfo CurrentCulture
        {
            get
            {
                return Thread.CurrentThread.CurrentCulture;
            }
        }

        /// <summary>
        /// 资源的根名称。
        /// </summary>
        public virtual string BaseName
        {
            get
            {
                return $"{ResourceAssembly.GetName().Name}.Properties.{ResourceName}_{CurrentCulture.Name.Replace("-", "_")}";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private ResourceManager _resourceManager;

        /// <summary>
        /// 返回指定的 System.String 资源的值。
        /// </summary>
        /// <param name="name">要获取的资源名。</param>
        /// <returns>针对调用方的当前区域性设置而本地化的资源的值。如果不可能有匹配项，则返回 null。</returns>
        public virtual string GetString(string name)
        {
            if (_resourceManager.IsNull())
            {
                _resourceManager = new ResourceManager(BaseName, ResourceAssembly);
            }
            return _resourceManager.GetString(name);
        }
    }
}
