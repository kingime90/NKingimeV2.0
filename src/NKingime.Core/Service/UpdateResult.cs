using System;
using NKingime.Core.Option;
using NKingime.Utility.General;

namespace NKingime.Core.Service
{
    /// <summary>
    /// 更新消息结果。
    /// </summary>
    public class UpdateResult : MessageResult<UpdateResultOption>
    {
        /// <summary>
        /// 初始化一个<see cref="UpdateResult"/>类型的成功实例。
        /// </summary>
        public UpdateResult() : base(UpdateResultOption.Success)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="UpdateResult"/>类型的新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        public UpdateResult(UpdateResultOption result) : base(result)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="UpdateResult"/>类型的新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="message">消息。</param>
        public UpdateResult(UpdateResultOption result, string message) : base(result, message)
        {

        }
    }
}
