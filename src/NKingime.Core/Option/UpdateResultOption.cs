
namespace NKingime.Core.Option
{
    /// <summary>
    /// 更新结果选项。
    /// </summary>
    public enum UpdateResultOption : byte
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
        /// 约束/限制。
        /// </summary>
        Constraint = 3,

        /// <summary>
        /// 成功。
        /// </summary>
        Success = 4,
    }
}
