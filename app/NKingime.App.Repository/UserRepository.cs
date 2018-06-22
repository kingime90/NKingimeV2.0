using System;
using NKingime.App.Entity;
using NKingime.Entity.Data;
using NKingime.App.IRepository;
using NKingime.Entity.Dependency;

namespace NKingime.App.Repository
{
    /// <summary>
    /// 用户信息数据实体仓储。
    /// </summary>
    public class UserRepository : Repository<User, long>, IUserRepository
    {
        /// <summary>
        /// 初始化一个<see cref="UserRepository"/>类型的新实例。
        /// </summary>
        public UserRepository(IDbContextTypeResolver contextTypeResolver) : base(contextTypeResolver)
        {

        }
    }
}
