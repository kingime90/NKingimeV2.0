using System;
using NKingime.Entity.Mapper;

namespace NKingime.App.Entity.Mapper
{
    /// <summary>
    /// 用户信息实体映射配置。
    /// </summary>
    public class UserMapper : DefaultEntityMapper<User, long>
    {
        /// <summary>
        /// 属性映射。
        /// </summary>
        protected override void PropertyMapping()
        {
            //HasColumnAnnotation 用于存储属性的数据库列的模型中设置注释
            //HasColumnName 配置用于存储属性的数据库列的名称
            //HasColumnOrder 配置用于存储属性的数据库列的顺序
            //HasColumnType 配置用于存储属性的数据库列的数据类型
            //HasDatabaseGeneratedOption 配置数据库如何生成属性的值
            //HasMaxLength 将属性配置为具有指定的最大长度
            //IsFixedLength 将属性配置为固定长度 char
            //IsMaxLength 将属性配置为允许使用数据库提供程序支持的最大长度
            //IsOptional 将属性配置为可选属性。用于存储此属性的数据库列将可以为 null
            //IsRequired 将属性配置为必需属性。用于存储此属性的数据库列将不可以为 null
            //IsUnicode 将属性配置为支持 Unicode 字符串内容。true nvarchar，false varchar
            //IsVariableLength 将属性配置为可变长度。默认情况下，System.string 属性为可变长度

            //Property(t => t.Id).IsUnicode(false).HasMaxLength(20);
            Property(t => t.Username).IsUnicode(false).HasMaxLength(30);
            Property(t => t.Mobile).IsUnicode(false).HasMaxLength(20);
            Property(t => t.Email).IsUnicode(false).HasMaxLength(50);
        }
    }
}
