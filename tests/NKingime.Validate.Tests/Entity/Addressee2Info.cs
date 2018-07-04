using System;
using System.ComponentModel;

namespace NKingime.Validate.Tests.Entity
{
    /// <summary>
    /// 收件人2信息
    /// </summary>
    [Description("收件人2信息")]
    public class Addressee2Info : IEntity
    {
        /// <summary>
        /// 姓名2。
        /// </summary>
        [Description("姓名2")]
        public string Name { get; set; }

        /// <summary>
        /// 省2
        /// </summary>
        [Description("省2")]
        public string Province { get; set; }

        /// <summary>
        /// 市2
        /// </summary>
        [Description("市2")]
        public string City { get; set; }

        /// <summary>
        /// 区2
        /// </summary>
        [Description("区2")]
        public string Region { get; set; }

        /// <summary>
        /// 镇2
        /// </summary>
        [Description("镇2")]
        public string Town { get; set; }

        /// <summary>
        /// 地址2
        /// </summary>
        [Description("地址2")]
        public string Address { get; set; }
    }
}
