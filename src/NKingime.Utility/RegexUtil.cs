using System;
using System.Text.RegularExpressions;

namespace NKingime.Utility
{
    /// <summary>
    /// 正则表达式应用。
    /// </summary>
    public static class RegexUtil
    {
        /// <summary>
        /// 电子邮箱正则表达式模式。
        /// </summary>
        public const string EmailPattern = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        /// <summary>
        /// 中文正则表达式模式。
        /// </summary>
        public const string ChinesePattern = @"^[\u4e00-\u9fa5]{0,}$";

        /// <summary>
        /// 统一资源定位符正则表达式模式。
        /// </summary>
        public const string URLPattern = @"^(https?|ftp|file|ws)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";

        /// <summary>
        /// 英文字母正则表达式模式。
        /// </summary>
        public const string LetterPattern = @"^[A-Za-z]+$";

        /// <summary>
        /// 小写英文字母正则表达式模式。
        /// </summary>
        public const string LowerLetterPattern = @"^[a-z]+$";

        /// <summary>
        /// 大写英文字母正则表达式模式。
        /// </summary>
        public const string UpperLetterPattern = @"^[A-Z]+$";

        /// <summary>
        /// 手机号码正则表达式模式。
        /// </summary>
        public const string CellphonePattern = @"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$";

        /// <summary>
        /// 指示指定的字符串是不是电子邮箱。
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <returns></returns>
        public static bool IsEmail(string input)
        {
            return IsMatch(input, EmailPattern);
        }

        /// <summary>
        /// 指示指定的字符串是不是中文。
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <returns></returns>
        public static bool IsChinese(string input)
        {
            return IsMatch(input, ChinesePattern);
        }

        /// <summary>
        /// 指示指定的字符串是不是统一资源定位符。
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <returns></returns>
        public static bool IsURL(string input)
        {
            return IsMatch(input, URLPattern);
        }

        /// <summary>
        /// 指示指定的字符串是不是由英文字母组成。
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <returns></returns>
        public static bool IsLetter(string input)
        {
            return IsMatch(input, LetterPattern);
        }

        /// <summary>
        /// 指示指定的字符串是不是由小写英文字母组成。
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <returns></returns>
        public static bool IsLowerLetter(string input)
        {
            return IsMatch(input, LowerLetterPattern);
        }

        /// <summary>
        /// 指示指定的字符串是不是由大写英文字母组成。
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <returns></returns>
        public static bool IsUpperLetter(string input)
        {
            return IsMatch(input, UpperLetterPattern);
        }

        /// <summary>
        /// 指示指定的字符串是不是手机号码。
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <returns></returns>
        public static bool IsCellphone(string input)
        {
            return IsMatch(input, CellphonePattern);
        }

        /// <summary>
        /// 指示所指定的正则表达式在指定的输入字符串中是否找到了匹配项。
        /// </summary>
        /// <param name="input">要搜索匹配项的字符串。</param>
        /// <param name="pattern">要匹配的正则表达式模式。</param>
        /// <returns>如果正则表达式找到匹配项，则为 true；否则，为 false。</returns>
        public static bool IsMatch(string input, string pattern)
        {
            return Regex.IsMatch(input, pattern);
        }
    }
}
