using System;
using NKingime.Utility.General;

namespace NKingime.Validate
{
    /// <summary>
    /// 验证消息结果。
    /// </summary>
    public class ValidMessageResult : MessageResult<bool>
    {
        /// <summary>
        /// 初始化一个<see cref="ValidMessageResult"/>类型的true实例。
        /// </summary>
        public ValidMessageResult() : base(true)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="ValidMessageResult"/>类型的新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        public ValidMessageResult(bool result) : base(result)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="ValidMessageResult"/>类型的新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="message">消息。</param>
        public ValidMessageResult(bool result, string message) : base(result, message)
        {

        }
    }
}
