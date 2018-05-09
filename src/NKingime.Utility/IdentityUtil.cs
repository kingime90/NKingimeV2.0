using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKingime.Utility
{
    /// <summary>
    /// 唯一标识生成应用。
    /// </summary>
    public static class IdentityUtil
    {
        /// <summary>
        /// 生成十六进制唯一标识。
        /// </summary>
        /// <returns></returns>
        public static string GenerateHex()
        {
            long identity = 1;
            byte[] buffer = Guid.NewGuid().ToByteArray();
            foreach (byte b in buffer)
            {
                identity *= ((int)b + 1);
            }
            string hex = string.Format("{0:x}", identity - DateTime.Now.Ticks);
            return hex.PadRight(16, '0');
        }
    }
}
