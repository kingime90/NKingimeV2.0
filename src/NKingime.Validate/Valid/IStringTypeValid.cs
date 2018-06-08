﻿using System;

namespace NKingime.Validate
{
    /// <summary>
    /// 定义字符串类型验证接口。
    /// </summary>
    public interface IStringTypeValid : ITypeValid
    {
        /// <summary>
        /// 设置是否必填，默认必填。
        /// </summary>
        /// <param name="isRequired">是否必填。</param>
        /// <returns></returns>
        IStringTypeValid Required(bool isRequired = true);

        /// <summary>
        /// 指定的字符串类型最小长度。
        /// </summary>
        /// <param name="minValue">最小长度。</param>
        /// <param name="stringType">字符串类型选项，默认 <see cref="StringTypeOption.String"/>。</param>
        /// <returns></returns>
        IStringTypeValid MinLength(int minValue, StringTypeOption stringType = StringTypeOption.String);

        /// <summary>
        /// 指定的字符串类型最大长度。
        /// </summary>
        /// <param name="maxValue">最大长度。</param>
        /// <param name="stringType">字符串类型选项，默认 <see cref="StringTypeOption.String"/>。</param>
        /// <returns></returns>
        IStringTypeValid MaxLength(int maxValue, StringTypeOption stringType = StringTypeOption.String);

        /// <summary>
        /// 指定的字符串类型长度范围。
        /// </summary>
        /// <param name="minValue">最小长度。</param>
        /// <param name="maxValue">最大长度。</param>
        /// <param name="stringType">字符串类型选项，默认 <see cref="StringTypeOption.String"/>。</param>
        /// <returns></returns>
        IStringTypeValid LengthRange(int minValue, int maxValue, StringTypeOption stringType = StringTypeOption.String);

        /// <summary>
        ///  配置正则式。
        /// </summary>
        /// <param name="regexTypes">正则式类型选项数组。</param>
        /// <returns></returns>
        IStringTypeValid Matchs(params RegexTypeOption[] regexTypes);

        /// <summary>
        /// 自定义验证。
        /// </summary>
        /// <param name="valid">自定义验证函数。</param>
        /// <returns></returns>
        IStringTypeValid Custom(Func<object, string, ValidResult> valid);
    }
}
