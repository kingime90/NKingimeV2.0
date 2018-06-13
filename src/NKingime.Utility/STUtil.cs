using System;
using Antlr3.ST;
using System.Collections.Generic;
using NKingime.Utility.General;
using NKingime.Utility.Extensions;

namespace NKingime.Utility
{
    /// <summary>
    /// 字符串模板应用（StringTemplate）。
    /// </summary>
    public static class STUtil
    {
        /// <summary>
        /// 获取字符串模板内容。 
        /// </summary>
        /// <typeparam name="T">值类型。</typeparam>
        /// <param name="template">字符串模板。</param>
        /// <param name="parameters">参数集合。</param>
        /// <returns></returns>
        public static string GetString<T>(string template, IDictionary<string, T> attributes)
        {
            var sTemplate = new StringTemplate(template);
            if (attributes.IsNotNull())
            {
                foreach (var item in attributes)
                {
                    sTemplate.SetAttribute(item.Key, item.Value);
                }
            }
            return sTemplate.ToString();
        }

        /// <summary>
        /// 获取字符串模板内容。
        /// </summary>
        /// <typeparam name="T">值类型。</typeparam>
        /// <param name="template">字符串模板。</param>
        /// <param name="parameters">参数数组。</param>
        /// <returns></returns>
        public static string GetString<T>(string template, params STAttribute<T>[] attributes)
        {
            var sTemplate = new StringTemplate(template);
            if (attributes.IsNotNull())
            {
                foreach (var parameter in attributes)
                {
                    sTemplate.SetAttribute(parameter.Key, parameter.Value);
                }
            }
            return sTemplate.ToString();
        }

        /// <summary>
        /// 获取字符串模板内容。
        /// </summary>
        /// <typeparam name="T">值类型。</typeparam>
        /// <param name="template">字符串模板。</param>
        /// <param name="name">参数名称。</param>
        /// <param name="value">参数值。</param>
        /// <returns></returns>
        public static string GetString<T>(string template, string name, T value)
        {
            return GetString(template, new STAttribute<T>(name, value));
        }
    }
}
