﻿using System;
using NKingime.Utility.General;

namespace NKingime.Validate
{
    /// <summary>
    /// 值类型验证。
    /// </summary>
    /// <typeparam name="T">值类型类型。</typeparam>
    public class ValueTypeValid<T> : TypeValidBase, IValueTypeValid<T> where T : struct
    {
        /// <summary>
        /// 验证规则。
        /// </summary>
        private ValueTypeRule<T> _validRule = new ValueTypeRule<T>();

        /// <summary>
        /// 初始化一个<see cref="ValueTypeValid"/>类型的新实例。
        /// </summary>
        public ValueTypeValid() : base()
        {

        }

        /// <summary>
        /// 初始化一个<see cref="ValueTypeValid"/>类型的新实例。
        /// </summary>
        /// <param name="i18nResource">全球化资源。</param>
        public ValueTypeValid(I18nResourceBase i18nResource) : base(i18nResource)
        {

        }

        /// <summary>
        /// 设置验证最小值。
        /// </summary>
        /// <param name="value">最小值。</param>
        /// <returns></returns>
        public IValueTypeValid<T> MinValue(T value)
        {
            SetTypeRuleRange(ValueTypeOption.MinValue, value, default(T));
            return this;
        }

        /// <summary>
        /// 设置验证最大值。
        /// </summary>
        /// <param name="value">最大值。</param>
        /// <returns></returns>
        public IValueTypeValid<T> MaxValue(T value)
        {
            SetTypeRuleRange(ValueTypeOption.MaxValue, default(T), value);
            return this;
        }

        /// <summary>
        /// 设置验证值范围。
        /// </summary>
        /// <param name="minValue">最小值。</param>
        /// <param name="maxValue">最大值。</param>
        /// <returns></returns>
        public IValueTypeValid<T> Range(T minValue, T maxValue)
        {
            SetTypeRuleRange(ValueTypeOption.Range, minValue, maxValue);
            return this;
        }

        /// <summary>
        /// 设置自定义验证。
        /// </summary>
        /// <param name="valid">自定义验证函数。</param>
        /// <returns></returns>
        public IValueTypeValid<T> Custom(Func<T, object, ValidMessageResult> valid)
        {
            _validRule.CustomValid = valid;
            return this;
        }

        /// <summary>
        /// 验证值是否满足规则。
        /// </summary>
        /// <param name="value">需要验证的值。</param>
        /// <param name="name">需要验证的值的名称。</param>
        /// <param name="description">需要验证的值的描述。</param>
        /// <param name="root">需要验证的值的根对象，如果没有，则为 null。</param>
        /// <returns></returns>
        public override ValidResult Validate(object value, string name, string description, object root = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 设置类型验证规则范围。
        /// </summary>
        /// <param name="valueType">值类型比较选项。</param>
        /// <param name="minValue">最小值。</param>
        /// <param name="maxValue">最大值。</param>
        private void SetTypeRuleRange(ValueTypeOption valueType, T minValue, T maxValue)
        {
            _validRule.ValueType = valueType;
            _validRule.MinValue = minValue;
            _validRule.MaxValue = maxValue;
        }
    }
}
