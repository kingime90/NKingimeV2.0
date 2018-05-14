using System;
using NKingime.App.IService;
using NKingime.App.IRepository;

namespace NKingime.App.Service
{
    /// <summary>
    /// 用户服务。
    /// </summary>
    public class UserService : IUserService
    {
        /// <summary>
        /// 获取或设置 用户信息数据仓储接口。
        /// </summary>
        public IUserRepository UserRepository { get; set; }


    }
}
