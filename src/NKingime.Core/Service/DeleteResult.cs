using System;
using NKingime.Core.Option;
using NKingime.Utility.General;

namespace NKingime.Core.Service
{
    /// <summary>
    /// 删除消息结果。
    /// </summary>
    public class DeleteResult : MessageResult<DeleteResultOption>
    {
        /// <summary>
        /// 初始化一个<see cref="DeleteResult"/>类型的成功实例。
        /// </summary>
        public DeleteResult() : base(DeleteResultOption.Success)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="DeleteResult"/>类型的新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        public DeleteResult(DeleteResultOption result) : base(result)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="DeleteResult"/>类型的新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="message">消息。</param>
        public DeleteResult(DeleteResultOption result, string message) : base(result, message)
        {

        }
    }
}
