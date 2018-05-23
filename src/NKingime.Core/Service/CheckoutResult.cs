using System;
using NKingime.Core.Option;

namespace NKingime.Core.Service
{
    /// <summary>
    /// 校验操作结果。
    /// </summary>
    public class CheckoutResult : OperateResult<CheckResultOption>
    {
        /// <summary>
        /// 初始化一个<see cref="CheckoutResult"/>成功实例。
        /// </summary>
        public CheckoutResult() : base(CheckResultOption.Pass)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="CheckoutResult"/>新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        public CheckoutResult(CheckResultOption result) : base(result)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="CheckoutResult"/>新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="message">消息。</param>
        public CheckoutResult(CheckResultOption result, string message) : base(result, message)
        {

        }
    }
}
