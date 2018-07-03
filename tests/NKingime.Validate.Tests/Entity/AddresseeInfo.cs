using System;
using System.ComponentModel;

namespace NKingime.Validate.Tests.Entity
{
    /// <summary>
    /// 收件人信息
    /// </summary>
    [Description("收件人信息")]
    public class AddresseeInfo : IEntity
    {
        /// <summary>
        /// 姓名。
        /// </summary>
        [Description("姓名")]
        public string Name { get; set; }

        /// <summary>
        /// 省
        /// </summary>
        [Description("省")]
        public string Province { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [Description("市")]
        public string City { get; set; }

        /// <summary>
        /// 区
        /// </summary>
        [Description("区")]
        public string Region { get; set; }

        /// <summary>
        /// 镇
        /// </summary>
        [Description("镇")]
        public string Town { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [Description("地址")]
        public string Address { get; set; }
    }
}
