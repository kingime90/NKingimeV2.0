using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NKingime.Core.Entity
{
    /// <summary>
    /// 可复制的数据实体基类。
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    [Serializable]
    public abstract class CloneableEntity<TKey> : IEntity<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 主键ID。
        /// </summary>
        public abstract TKey Id { get; set; }

        /// <summary>
        /// 创建作为当前实例副本的新对象。
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var formatter = new BinaryFormatter();
            var stream = new MemoryStream();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            object result = formatter.Deserialize(stream);
            stream.Close();
            return result;
        }
    }
}
