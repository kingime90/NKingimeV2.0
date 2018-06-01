using System;
using NKingime.Utility.General;

namespace NKingime.Validate
{
    /// <summary>
    /// 验证消息结果。
    /// </summary>
    public class ValidResult : MessageResult<bool>
    {
        /// <summary>
        /// 初始化一个<see cref="ValidResult"/>成功实例。
        /// </summary>
        public ValidResult() : base(true)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="ValidResult"/>新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        public ValidResult(bool result) : base(result)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="ValidResult"/>新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="message">消息。</param>
        public ValidResult(bool result, string message) : base(result, message)
        {

        }
    }
}
