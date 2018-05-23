using System;
using System.ComponentModel;

namespace NKingime.App.Entity.Option
{
    /// <summary>
    /// 性别选项。
    /// </summary>
    [Description("性别选项")]
    public enum GenderOption : byte
    {
        /// <summary>
        /// 未知。
        /// </summary>
        [Description("未知")]
        Unknown = 0,

        /// <summary>
        /// 男。
        /// </summary>
        [Description("男")]
        Male = 1,

        /// <summary>
        /// 女。
        /// </summary>
        [Description("女")]
        Female = 2,
    }
}
