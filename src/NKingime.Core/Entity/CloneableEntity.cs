using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NKingime.Utility.General;

namespace NKingime.Core.Entity
{
    /// <summary>
    /// 可复制的数据实体基类。
    /// </summary>
    /// <typeparam name="TKey">主键类型。</typeparam>
    [Serializable]
    public abstract class CloneableEntity<TKey> : Cloneable, IEntity<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 主键ID。
        /// </summary>
        public abstract TKey Id { get; set; }
    }
}
