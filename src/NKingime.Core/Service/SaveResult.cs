﻿using System;
using NKingime.Core.Option;
using NKingime.Utility.General;

namespace NKingime.Core.Service
{
    /// <summary>
    /// 保存消息结果。
    /// </summary>
    public class SaveResult : MessageResult<SaveResultOption>
    {
        /// <summary>
        /// 初始化一个<see cref="SaveResult"/>类型的成功实例。
        /// </summary>
        public SaveResult() : base(SaveResultOption.Success)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="SaveResult"/>类型的新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        public SaveResult(SaveResultOption result) : base(result)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="SaveResult"/>类型的新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="message">消息。</param>
        public SaveResult(SaveResultOption result, string message) : base(result, message)
        {

        }
    }
}
