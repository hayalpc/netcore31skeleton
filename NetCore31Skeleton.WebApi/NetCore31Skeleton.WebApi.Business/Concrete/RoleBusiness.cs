using NetCore31Skeleton.Library.Log;
using NetCore31Skeleton.Library.Repository.Interfaces;
using NetCore31Skeleton.WebApi.Business.Interfaces;
using NetCore31Skeleton.WebApi.Repository;
using NetCore31Skeleton.WebApi.Repository.Context;
using NetCore31Skeleton.WebApi.Repository.Models;

namespace NetCore31Skeleton.WebApi.Business.Concrete
{
    public class RoleBusiness : CoreBusiness<AppRole, int>, IRoleBusiness
    {
        private readonly ICoreRepository<AppRole, int> repository;
        private readonly IGenericUnitOfWork<CoreDbContext> unitOfWork;
        private readonly IGenericLogger logger;

        public RoleBusiness(ICoreRepository<AppRole, int> repository, IGenericUnitOfWork<CoreDbContext> unitOfWork, IGenericLogger logger)
            : base(repository, unitOfWork, logger)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }


    }
}
