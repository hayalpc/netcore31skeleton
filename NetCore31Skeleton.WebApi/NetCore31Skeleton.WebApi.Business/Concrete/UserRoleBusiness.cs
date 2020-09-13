using NetCore31Skeleton.Library.Log;
using NetCore31Skeleton.Library.Repository.Interfaces;
using NetCore31Skeleton.WebApi.Business.Interfaces;
using NetCore31Skeleton.WebApi.Core.Results;
using NetCore31Skeleton.WebApi.Repository;
using NetCore31Skeleton.WebApi.Repository.Context;
using NetCore31Skeleton.WebApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCore31Skeleton.WebApi.Business.Concrete
{
    public class UserRoleBusiness : CoreBusiness<AppUserRole, int>, IUserRoleBusiness
    {
        private readonly ICoreRepository<AppUserRole, int> repository;
        private readonly IGenericUnitOfWork<CoreDbContext> unitOfWork;
        private readonly IGenericLogger logger;

        public UserRoleBusiness(ICoreRepository<AppUserRole, int> repository, IGenericUnitOfWork<CoreDbContext> unitOfWork, IGenericLogger logger)
            : base(repository, unitOfWork, logger)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public IDataResult<List<AppRole>> GetRolesByUserId(int Id)
        {
            try
            {
                unitOfWork.SetIsolationLevel(System.Data.IsolationLevel.ReadUncommitted);
                var entity = repository.GetQuery(x => x.AppUserId == Id
                    && x.AppRole.StatusId == Library.Repository.Status.Active
                ).Select(x => x.AppRole).ToList();

                if (entity != null)
                    return new SuccessDataResult<List<AppRole>>(entity);
                else
                    return new ErrorDataResult<List<AppRole>>("RolesNotFound");
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
                return new ErrorDataResult<List<AppRole>>(500, exp.Message);
            }
        }

    }
}
