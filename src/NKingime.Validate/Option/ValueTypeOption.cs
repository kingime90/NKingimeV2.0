using System;
using System.ComponentModel;

namespace NKingime.Validate
{
    /// <summary>
    /// 值类型验证选项。
    /// </summary>
    [Description("值类型验证选项")]
    public enum ValueTypeOption
    {
        /// <summary>
        /// 最小值。
        /// </summary>
        [Description("最小值")]
        MinValue,

        /// <summary>
        /// 最大值。
        /// </summary>
        [Description("最大值")]
        MaxValue,

        /// <summary>
        /// 范围。
        /// </summary>
        [Description("范围")]
        Range
    }
}
