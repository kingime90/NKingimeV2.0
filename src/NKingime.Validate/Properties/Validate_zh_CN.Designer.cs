﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace NKingime.Validate.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Validate_zh_CN {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Validate_zh_CN() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NKingime.Validate.Properties.Validate_zh_CN", typeof(Validate_zh_CN).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 字符个数必须在 $minValue$ 到 $maxValue$ 之间 的本地化字符串。
        /// </summary>
        internal static string ByteLengthRangeError {
            get {
                return ResourceManager.GetString("ByteLengthRangeError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 不是正确的中文格式 的本地化字符串。
        /// </summary>
        internal static string ChineseError {
            get {
                return ResourceManager.GetString("ChineseError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 不是正确的邮箱格式 的本地化字符串。
        /// </summary>
        internal static string EmailError {
            get {
                return ResourceManager.GetString("EmailError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 不能超过 $maxValue$ 个字符，一个汉字占两个字符 的本地化字符串。
        /// </summary>
        internal static string MaxByteLengthError {
            get {
                return ResourceManager.GetString("MaxByteLengthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似  的本地化字符串。
        /// </summary>
        internal static string MinByteLengthError {
            get {
                return ResourceManager.GetString("MinByteLengthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 必填 的本地化字符串。
        /// </summary>
        internal static string RequiredError {
            get {
                return ResourceManager.GetString("RequiredError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 字符长度必须在 {0} 到 {1} 之间 的本地化字符串。
        /// </summary>
        internal static string StringLengthRangeError {
            get {
                return ResourceManager.GetString("StringLengthRangeError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 不能超过 $maxValue$ 个字符 的本地化字符串。
        /// </summary>
        internal static string StringMaxLengthError {
            get {
                return ResourceManager.GetString("StringMaxLengthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 不能少于 $minValue$ 个字符 的本地化字符串。
        /// </summary>
        internal static string StringMinLengthError {
            get {
                return ResourceManager.GetString("StringMinLengthError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 不是正确的URL格式 的本地化字符串。
        /// </summary>
        internal static string URLError {
            get {
                return ResourceManager.GetString("URLError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 不能大于  $minValue$ 的本地化字符串。
        /// </summary>
        internal static string ValueTypeMaxValueError {
            get {
                return ResourceManager.GetString("ValueTypeMaxValueError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 不能小于  $minValue$ 的本地化字符串。
        /// </summary>
        internal static string ValueTypeMinValueError {
            get {
                return ResourceManager.GetString("ValueTypeMinValueError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 必须在 $minValue$ 到 $minValue$ 之间 的本地化字符串。
        /// </summary>
        internal static string ValueTypeRangeError {
            get {
                return ResourceManager.GetString("ValueTypeRangeError", resourceCulture);
            }
        }
    }
}