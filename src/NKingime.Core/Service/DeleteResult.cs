using System;
using NKingime.Core.Option;

namespace NKingime.Core.Service
{
    /// <summary>
    /// 删除操作结果。
    /// </summary>
    public class DeleteResult : OperateResult<DeleteResultOption>
    {
        /// <summary>
        /// 初始化一个<see cref="DeleteResult"/>成功实例。
        /// </summary>
        public DeleteResult() : base(DeleteResultOption.Success)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="DeleteResult"/>新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        public DeleteResult(DeleteResultOption result) : base(result)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="DeleteResult"/>新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="message">消息。</param>
        public DeleteResult(DeleteResultOption result, string message) : base(result, message)
        {

        }
    }
}
