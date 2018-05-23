using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NKingime.Utility.General
{
    /// <summary>
    /// 支持克隆，即用与现有实例相同的值创建类的新实例。
    /// </summary>
    [Serializable]
    public class Cloneable : ICloneable
    {
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
