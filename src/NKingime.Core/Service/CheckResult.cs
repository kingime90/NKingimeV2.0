using System;
using NKingime.Core.Option;

namespace NKingime.Core.Service
{
    /// <summary>
    /// 校验操作结果。
    /// </summary>
    public class CheckResult : OperateResult<CheckResultOption>
    {
        /// <summary>
        /// 初始化一个<see cref="CheckResult"/>成功实例。
        /// </summary>
        public CheckResult() : base(CheckResultOption.Pass)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="CheckResult"/>新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        public CheckResult(CheckResultOption result) : base(result)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="CheckResult"/>新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="message">消息。</param>
        public CheckResult(CheckResultOption result, string message) : base(result, message)
        {

        }
    }
}
