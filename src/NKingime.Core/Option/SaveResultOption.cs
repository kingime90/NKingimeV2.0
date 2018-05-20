
namespace NKingime.Core.Option
{
    /// <summary>
    /// 保存结果选项。
    /// </summary>
    public enum SaveResultOption : byte
    {
        /// <summary>
        /// 参数错误。
        /// </summary>
        ArgumentError = 1,

        /// <summary>
        /// 约束/限制。
        /// </summary>
        Constraint = 2,

        /// <summary>
        /// 成功。
        /// </summary>
        Success = 3,
    }
}
