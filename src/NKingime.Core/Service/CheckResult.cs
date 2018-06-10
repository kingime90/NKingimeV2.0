using System;
using NKingime.Core.Option;
using NKingime.Utility.General;

namespace NKingime.Core.Service
{
    /// <summary>
    /// 校验消息结果。
    /// </summary>
    public class CheckResult : MessageResult<CheckResultOption>
    {
        /// <summary>
        /// 初始化一个<see cref="CheckResult"/>类型的通过实例。
        /// </summary>
        public CheckResult() : base(CheckResultOption.Pass)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="CheckResult"/>类型的新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        public CheckResult(CheckResultOption result) : base(result)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="CheckResult"/>类型的新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="message">消息。</param>
        public CheckResult(CheckResultOption result, string message) : base(result, message)
        {

        }
    }
}
