using System;
using System.ComponentModel;

namespace NKingime.Validate
{
    /// <summary>
    /// 字符串类型选项。
    /// </summary>
    [Description("字符串类型选项")]
    public enum StringTypeOption
    {
        /// <summary>
        /// 字符串。
        /// </summary>
        [Description("字符串")]
        String,

        /// <summary>
        /// 字节（汉字占两个字节）。
        /// </summary>
        [Description("字节")]
        Byte,
    }
}
