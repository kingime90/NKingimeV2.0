using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Validate.Tests.Entity
{
    /// <summary>
    /// 创建人
    /// </summary>
    /// 
    public class Creater : IEntity
    {
        /// <summary>
        /// 编号。
        /// </summary>
        [Description("编号")]
        public string CreaterId { get; set; }

        /// <summary>
        /// 姓名。
        /// </summary>
        [Description("姓名")]
        public string CreaterName { get; set; }
    }
}
