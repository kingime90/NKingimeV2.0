using System;
using System.ComponentModel;

namespace NKingime.Validate
{
    /// <summary>
    /// 正则式类型选项。
    /// </summary>
    [Description("正则式类型选项")]
    public enum RegexTypeOption
    {
        /// <summary>
        /// 邮箱。
        /// </summary>
        [Description("邮箱")]
        Email,

        /// <summary>
        /// 中文。
        /// </summary>
        [Description("中文")]
        Chinese,

        /// <summary>
        /// 统一资源定位符。
        /// </summary>
        [Description("统一资源定位符")]
        URL
    }
}
