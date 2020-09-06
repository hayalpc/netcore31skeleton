﻿using NetCore31Skeleton.Library.Repository.Interfaces;
using NetCore31Skeleton.WebApi.Repository.Context;
using NetCore31Skeleton.WebApi.Repository.Models;

namespace NetCore31Skeleton.WebApi.Repository.Interfaces
{
    public interface IAppRoleRepository : IGenericRepository<int, AppRole, CoreDbContext>
    {
    }
}