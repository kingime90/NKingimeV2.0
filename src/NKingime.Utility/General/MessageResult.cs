using System;

namespace NKingime.Utility.General
{
    /// <summary>
    /// 消息结果基类。
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public abstract class MessageResult<TResult> where TResult : struct
    {
        /// <summary>
        /// 初始化一个<see cref="MessageResult{TResult}"/>类型的新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        public MessageResult(TResult result = default(TResult))
        {
            Result = result;
        }

        /// <summary>
        /// 初始化一个<see cref="MessageResult{TResult}"/>类型的新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="message">消息。</param>
        public MessageResult(TResult result, string message) : this(result)
        {
            Message = message;
        }

        /// <summary>
        /// 获取 结果。
        /// </summary>
        public TResult Result { get; protected set; }

        /// <summary>
        /// 获取 消息。
        /// </summary>
        public string Message { get; protected set; }

        /// <summary>
        /// 设置结果。
        /// </summary>
        /// <param name="result">结果。</param>
        public virtual void SetResult(TResult result)
        {
            Result = result;
        }

        /// <summary>
        /// 设置消息。
        /// </summary>
        /// <param name="message">消息。</param>
        public virtual void SetMessage(string message)
        {
            Message = message;
        }

        /// <summary>
        /// 设置结果。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="message">消息。</param>
        public virtual void SetResult(TResult result, string message)
        {
            Result = result;
            Message = message;
        }
    }
}
