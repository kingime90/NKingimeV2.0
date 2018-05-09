using System;

namespace NKingime.Utility
{
    /// <summary>
    /// 唯一标识应用。
    /// </summary>
    public static class IdentityUtil
    {
        /// <summary>
        /// 新的Guid字符串。
        /// </summary>
        /// <param name="format">一个单格式说明符，它指示如何格式化此 System.Guid 的值。format 参数可以是“N”、“D”、“B”、“P”或“X”。如果 format 为 null 或空字符串 ("")，则使用“D”。</param>
        /// <returns></returns>
        public static string NewGuid(string format = "N")
        {
            return Guid.NewGuid().ToString(format);
        }

        /// <summary>
        /// 新的十六进制唯一标识字符串。
        /// </summary>
        /// <returns></returns>
        public static string NewHex()
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

        /// <summary>
        /// 新的UUID。
        /// </summary>
        /// <returns></returns>
        public static long NewUUID()
        {
            byte[] bytes = Guid.NewGuid().ToByteArray();
            return BitConverter.ToInt64(bytes, 0);
        }
    }
}
