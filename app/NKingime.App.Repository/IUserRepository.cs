using System;
using NKingime.Core.Data;
using NKingime.App.Entity;

namespace NKingime.App.Repository
{
    /// <summary>
    /// 定义用户信息数据仓储接口。
    /// </summary>
    public interface IUserRepository : IRepository<User, string>
    {

    }
}
