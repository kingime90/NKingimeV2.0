using System;

namespace NKingime.Utility.General
{
    /// <summary>
    /// 消息布尔结果。
    /// </summary>
    public class BooleanResult : MessageResult<bool>
    {
        /// <summary>
        /// 初始化一个<see cref="BooleanResult"/>类型的true实例。
        /// </summary>
        public BooleanResult() : base(true)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="BooleanResult"/>类型的新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        public BooleanResult(bool result) : base(result)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="BooleanResult"/>类型的新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="message">消息。</param>
        public BooleanResult(bool result, string message) : base(result, message)
        {

        }
    }
}
