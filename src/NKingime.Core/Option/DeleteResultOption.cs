using System;

namespace NKingime.Core.Option
{
    /// <summary>
    /// 删除结果选项。
    /// </summary>
    public enum DeleteResultOption : byte
    {
        /// <summary>
        /// 参数错误。
        /// </summary>
        ArgumentError = 1,

        /// <summary>
        /// 未找到记录。
        /// </summary>
        NotFound = 2,

        /// <summary>
        /// 受限制。
        /// </summary>
        Limited = 3,

        /// <summary>
        /// 成功。
        /// </summary>
        Success = 4,
    }
}
