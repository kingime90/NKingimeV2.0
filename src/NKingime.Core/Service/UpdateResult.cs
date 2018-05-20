using System;
using NKingime.Core.Option;

namespace NKingime.Core.Service
{
    /// <summary>
    /// 更新操作结果。
    /// </summary>
    public class UpdateResult : OperateResult<UpdateResultOption>
    {
        /// <summary>
        /// 初始化一个<see cref="UpdateResult"/>成功实例。
        /// </summary>
        public UpdateResult() : base(UpdateResultOption.Success)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="UpdateResult"/>新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        public UpdateResult(UpdateResultOption result) : base(result)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="UpdateResult"/>新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="message">消息。</param>
        public UpdateResult(UpdateResultOption result, string message) : base(result, message)
        {

        }
    }
}
