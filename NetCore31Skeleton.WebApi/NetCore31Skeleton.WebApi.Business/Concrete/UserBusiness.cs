using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using NetCore31Skeleton.Core.Dtos;
using NetCore31Skeleton.Core.Enums;
using NetCore31Skeleton.Core.Results;
using NetCore31Skeleton.Core.Utils;
using NetCore31Skeleton.Library.Log;
using NetCore31Skeleton.Library.Repository.Interfaces;
using NetCore31Skeleton.WebApi.Business.Interfaces;
using NetCore31Skeleton.WebApi.Repository;
using NetCore31Skeleton.WebApi.Repository.Context;
using NetCore31Skeleton.WebApi.Repository.Models;
using System;
using System.Linq;

namespace NetCore31Skeleton.WebApi.Business.Concrete
{
    public class UserBusiness : CoreBusiness<AppUser, int>, IUserBusiness
    {
        private readonly ICoreRepository<AppUser, int> repository;
        private readonly ICoreRepository<AppRole, int> roleRepository;
        private readonly ICoreRepository<AppUserRole, int> userRoleRepository;

        private readonly IGenericUnitOfWork<CoreDbContext> unitOfWork;
        private readonly IGenericLogger logger;
        private readonly IMapper mapper;

        public UserBusiness(ICoreRepository<AppUser, int> repository, IGenericUnitOfWork<CoreDbContext> unitOfWork, IGenericLogger logger, IMapper mapper, ICoreRepository<AppRole, int> roleRepository, ICoreRepository<AppUserRole, int> userRoleRepository)
            : base(repository, unitOfWork, logger)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.logger = logger;
            this.mapper = mapper;
            this.roleRepository = roleRepository;
            this.userRoleRepository = userRoleRepository;
        }

        public IDataResult<AppUser> FindByUserName(string username)
        {
            try
            {
                var user = repository.GetQuery(u => u.StatusId == Library.Repository.Status.Active && u.Username == username).FirstOrDefault();
                return new SuccessDataResult<AppUser>(user);
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
                return new ErrorDataResult<AppUser>(500, exp.Message);
            }
        }

        public IDataResult<AppUser> Login(LoginDto loginDto)
        {
            try
            {
                var passwordMD5 = Helper.CreateMD5(loginDto.Username + loginDto.Password);
                var user = repository.GetQuery(u => u.StatusId == Library.Repository.Status.Active && u.Username == loginDto.Username && u.Password == passwordMD5).FirstOrDefault();
                if (user != null)
                    return new SuccessDataResult<AppUser>(user);
                else
                    return new ErrorDataResult<AppUser>("UserNotFound");
            }
            catch (Exception exp)
            {
                logger.Error(exp.ToString());
                return new ErrorDataResult<AppUser>(500, exp.Message);
            }
        }

        public IResult Register(RegisterDto registerDto)
        {
            var userCheck = repository.GetQuery(u => u.Email == registerDto.Email || u.Username == registerDto.Username).Any();
            if (!userCheck)
            {
                var user = mapper.Map<AppUser>(registerDto);
                var role = roleRepository.GetQuery(r => r.Name == RoleInfo.User).FirstOrDefault();
                try
                {
                    user.Password = Helper.CreateMD5(user.Username + user.Password);

                    unitOfWork.BeginTransaction();
                    repository.Insert(user);

                    unitOfWork.SaveChanges();

                    var userRole = new AppUserRole
                    {
                        AppUserId = user.Id,
                        AppRoleId = role.Id
                    };

                    userRoleRepository.Insert(userRole);

                    unitOfWork.SaveChanges();
                    unitOfWork.CommitTransaction();
                    return new SuccessResult("UserRegistered");
                }
                catch (Exception exp)
                {
                    unitOfWork.RollBackTransaction();
                    return new ErrorResult(500, exp.Message);
                }
            }
            return new ErrorResult(401, "UserExists");
        }
    }
}
