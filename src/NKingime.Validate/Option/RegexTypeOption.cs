using System;
using System.ComponentModel;

namespace NKingime.Validate
{
    /// <summary>
    /// 正则式类型选项。
    /// </summary>
    [Description("正则式类型选项")]
    public enum RegexTypeOption
    {
        /// <summary>
        /// 邮箱。
        /// </summary>
        [Description("邮箱")]
        Email,

        /// <summary>
        /// 中文。
        /// </summary>
        [Description("中文")]
        Chinese,

        /// <summary>
        /// 统一资源定位符。
        /// </summary>
        [Description("统一资源定位符")]
        URL,

        /// <summary>
        /// 英文字母。
        /// </summary>
        [Description("英文字母")]
        Letter,

        /// <summary>
        /// 小写英文字母。
        /// </summary>
        [Description("小写英文字母")]
        LowerLetter,

        /// <summary>
        /// 大写英文字母。
        /// </summary>
        [Description("大写英文字母")]
        UpperLetter,

        /// <summary>
        /// 手机号码。
        /// </summary>
        [Description("手机号码")]
        Cellphone,
    }
}
