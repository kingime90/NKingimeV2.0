using System;
using NKingime.Utility.Extensions;

namespace NKingime.Validate
{
    /// <summary>
    /// 验证结果。
    /// </summary>
    public sealed class ValidResult : ValidMessageResult
    {
        /// <summary>
        /// 初始化一个<see cref="ValidResult"/>类型的true实例。
        /// </summary>
        public ValidResult() : base(true)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="ValidResult"/>类型的新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        public ValidResult(bool result) : base(result)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="ValidResult"/>类型的新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="message">消息。</param>
        public ValidResult(bool result, string message) : base(result, message)
        {

        }

        /// <summary>
        /// 初始化一个<see cref="ValidResult"/>类型的新实例。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="name">验证的值的名称。</param>
        /// <param name="description">验证的值的描述。</param>
        public ValidResult(bool result, string name, string description) : base(result)
        {
            Name = name;
            Description = description;
        }

        /// <summary>
        /// 验证的值的名称。
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 验证的值的描述。
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// 设置验证的值的名称。
        /// </summary>
        /// <param name="name">验证的值的名称。</param>
        public void SetName(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 设置验证的值的描述。
        /// </summary>
        /// <param name="description">验证的值的描述。</param>
        public void SetDescription(string description)
        {
            Description = description;
        }

        /// <summary>
        /// 设置结果。
        /// </summary>
        /// <param name="result">结果。</param>
        /// <param name="name">验证的值的名称。</param>
        /// <param name="description">验证的值的描述。</param>
        /// <param name="message">消息。</param>
        public ValidResult SetResult(bool result, string name, string description, string message)
        {
            Result = result;
            Name = name;
            Description = description;
            Message = message;
            return this;
        }

        /// <summary>
        /// 重置。
        /// </summary>
        /// <param name="result">结果。</param>
        public ValidResult Reset(bool? result = false)
        {
            SetResult(result.IsTrue(), null, null, null);
            return this;
        }
    }
}
