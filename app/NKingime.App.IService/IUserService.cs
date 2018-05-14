using System;
using NKingime.App.Entity;
using NKingime.Core.Service;

namespace NKingime.App.IService
{
    /// <summary>
    /// 定义用户信息数据实体服务接口。
    /// </summary>
    public interface IUserService : IService<User, long>
    {

    }
}
