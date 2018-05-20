using System;

namespace NKingime.Core.Service
{
    /// <summary>
    /// 操作结果基类。
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public abstract class OperateResult<TResult> where TResult : struct
    {
        /// <summary>
        /// 初始化一个<see cref="ServiceResult{TResult}"/>新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        public OperateResult(TResult result = default(TResult))
        {
            Result = result;
        }

        /// <summary>
        /// 初始化一个<see cref="ServiceResult{TResult}"/>新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="message">消息。</param>
        public OperateResult(TResult result, string message) : this(result)
        {
            Message = message;
        }

        /// <summary>
        /// 获取 结果。
        /// </summary>
        public TResult Result { get; private set; }

        /// <summary>
        /// 获取 消息。
        /// </summary>
        public string Message { get; private set; }

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
