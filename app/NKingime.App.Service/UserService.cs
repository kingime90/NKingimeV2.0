﻿using System;
using NKingime.App.Entity;
using NKingime.App.IService;
using NKingime.App.IRepository;
using NKingime.Entity.Service;

namespace NKingime.App.Service
{
    /// <summary>
    /// 用户信息数据实体服务。
    /// </summary>
    public class UserService : ServiceBase<User, long>, IUserService
    {
        /// <summary>
        /// 获取或设置 当前数据实体仓储。
        /// </summary>
        protected IUserRepository EntityRepository { get; }

        /// <summary>
        /// 初始化一个<see cref="UserService"/>类型的新实例。
        /// </summary>
        /// <param name="userRepository"></param>
        public UserService(IUserRepository entityRepository) : base(entityRepository)
        {
            EntityRepository = entityRepository;
        }
    }
}
