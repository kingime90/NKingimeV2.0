using System;

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
        /// 字符串最小长度。
        /// </summary>
        /// <param name="minValue">最小长度。</param>
        /// <returns></returns>
        IStringTypeValid MinLength(int minValue);

        /// <summary>
        /// 字符串最大长度。
        /// </summary>
        /// <param name="maxValue">最大长度。</param>
        /// <returns></returns>
        IStringTypeValid MaxLength(int maxValue);

        /// <summary>
        /// 字符串长度范围。
        /// </summary>
        /// <param name="minValue">最小长度。</param>
        /// <param name="maxValue">最大长度。</param>
        /// <returns></returns>
        IStringTypeValid Range(int minValue, int maxValue);

        /// <summary>
        /// 字符最小个数。
        /// </summary>
        /// <param name="minValue">最小个数。</param>
        /// <returns></returns>
        IStringTypeValid CharMinLength(int minValue);

        /// <summary>
        /// 字符最大个数。
        /// </summary>
        /// <param name="maxValue">最大个数。</param>
        /// <returns></returns>
        IStringTypeValid CharMaxLength(int maxValue);

        /// <summary>
        /// 字符个数范围。
        /// </summary>
        /// <param name="minValue">最小个数。</param>
        /// <param name="maxValue">最大个数。</param>
        /// <returns></returns>
        IStringTypeValid CharRange(int minValue, int maxValue);

        /// <summary>
        ///  配置正则式。
        /// </summary>
        /// <param name="regexTypes">正则式类型选项数组。</param>
        /// <returns></returns>
        IStringTypeValid Match(params RegexTypeOption[] regexTypes);

        /// <summary>
        /// 自定义验证。
        /// </summary>
        /// <param name="valid">自定义验证函数。</param>
        /// <returns></returns>
        IStringTypeValid Custom(Func<object, string, ValidResult> valid);
    }
}
