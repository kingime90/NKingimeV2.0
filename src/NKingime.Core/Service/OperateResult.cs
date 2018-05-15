using System;

namespace NKingime.Core.Service
{
    /// <summary>
    /// 操作结果基类。
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public class OperateResult<TResult> where TResult : struct
    {
        /// <summary>
        /// 初始化一个<see cref="ServiceResult{TResult}"/>新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        public OperateResult(TResult result)
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
        public TResult Result { get; }

        /// <summary>
        /// 获取 消息。
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// 创建操作结果。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="message">消息，默认 null。</param>
        /// <returns></returns>
        public static OperateResult<TResult> CreateResult(TResult result, string message = null)
        {
            return new OperateResult<TResult>(result, message);
        }
    }
}
