using System;
using NKingime.Core.Data;
using NKingime.App.Entity;

namespace NKingime.App.IRepository
{
    /// <summary>
    /// 定义用户信息数据仓储接口。
    /// </summary>
    public interface IUserRepository : IRepository<User, long>
    {

    }
}
