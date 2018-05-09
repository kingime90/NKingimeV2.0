using System;
using NKingime.App.Entity;
using NKingime.Entity.Data;
using NKingime.Entity.Dependency;

namespace NKingime.App.Repository
{
    /// <summary>
    /// 定义用户信息数据仓储接口。
    /// </summary>
    public class UserRepository : Repository<User, long>, IUserRepository
    {
        /// <summary>
        /// 初始化一个<see cref="UserRepository"/>新实例。
        /// </summary>
        public UserRepository(IDbContextTypeResolver contextTypeResolver) : base(contextTypeResolver)
        {

        }
    }
}
