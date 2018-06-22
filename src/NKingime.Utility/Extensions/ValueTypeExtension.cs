using System;

namespace NKingime.Utility.Extensions
{
    /// <summary>
    /// 值类型扩展方法。
    /// </summary>
    public static class ValueTypeExtensions
    {
        /// <summary>
        /// 长时间格式（yyyy-MM-dd HH:mm:ss）。
        /// </summary>
        public const string LongTimeFormat = "yyyy-MM-dd HH:mm:ss";

        /// <summary>
        /// 日期格式（yyyy-MM-dd HH:mm:ss）。
        /// </summary>
        public const string DateFormat = "yyyy-MM-dd";

        #region 布尔值（bool）

        /// <summary>
        /// 如果否则条件。
        /// </summary>
        /// <typeparam name="T">泛型类型。</typeparam>
        /// <param name="assertion">要验证的断言。</param>
        /// <param name="trueVal">满足条件的值。</param>
        /// <param name="falseVal">不满足条件的值。</param>
        /// <returns></returns>
        public static T IfElse<T>(this bool assertion, T trueVal, T falseVal)
        {
            return assertion ? trueVal : falseVal;
        }

        /// <summary>
        /// 如果否则条件。
        /// </summary>
        /// <typeparam name="T">泛型类型。</typeparam>
        /// <param name="assertion">要验证的断言。</param>
        /// <param name="trueVal">满足条件的委托函数。</param>
        /// <param name="falseVal">不满足条件的值。</param>
        /// <returns></returns>
        public static T IfElse<T>(this bool assertion, Func<T> trueVal, T falseVal)
        {
            return assertion ? trueVal() : falseVal;
        }

        /// <summary>
        /// 如果否则条件。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assertion">要验证的断言。</param>
        /// <param name="trueVal">满足条件的值。</param>
        /// <param name="falseVal">不满足条件的委托函数。</param>
        /// <returns></returns>
        public static T IfElse<T>(this bool assertion, T trueVal, Func<T> falseVal)
        {
            return assertion ? trueVal : falseVal();
        }

        /// <summary>
        /// 如果否则条件。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="assertion">要验证的断言。</param>
        /// <param name="trueVal">满足条件的委托函数。</param>
        /// <param name="falseVal">不满足条件的委托函数。</param>
        /// <returns></returns>
        public static T IfElse<T>(this bool assertion, Func<T> trueVal, Func<T> falseVal)
        {
            return assertion ? trueVal() : falseVal();
        }

        #endregion

        #region 时间（DateTime）

        /// <summary>
        /// 格式化时间。
        /// </summary>
        /// <param name="value">要转换的值。</param>
        /// <param name="format">标准或自定义日期和时间格式的字符串。</param>
        /// <returns></returns>
        public static string FormatTime(this DateTime value, string format)
        {
            return value.ToString(format);
        }

        /// <summary>
        /// 转换为长时间格式字符串（yyyy-MM-dd HH:mm:ss）。
        /// </summary>
        /// <param name="value">要转换的值。</param>
        /// <returns></returns>
        public static string ToLongTimeFormat(this DateTime value)
        {
            return value.FormatTime(LongTimeFormat);
        }

        /// <summary>
        /// 转换为日期格式字符串（yyyy-MM-dd）。
        /// </summary>
        /// <param name="value">要转换的值。</param>
        /// <returns></returns>
        public static string ToDateFormat(this DateTime value)
        {
            return value.FormatTime(DateFormat);
        }

        #endregion

        #region 枚举（）

        /// <summary>
        /// 获取枚举项的全名称。
        /// </summary>
        /// <param name="value">枚举项。</param>
        /// <returns></returns>
        public static string GetFullName(this Enum value)
        {
            return $"{value.GetType().FullName}.{value}";
        }

        /// <summary>
        /// 获取枚举项的描述。
        /// </summary>
        /// <param name="value">枚举项。</param>
        /// <param name="attributeType">描述特性的类型信息。</param>
        /// <returns></returns>
        public static string GetDescription(this Enum value, Type attributeType = null)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            return fieldInfo?.GetDescription(attributeType);
        }

        #endregion
    }
}
