using AutoMapper;
using Microsoft.AspNetCore.Http;
using NetCore31Skeleton.Core.Dtos;
using NetCore31Skeleton.Core.Results;
using NetCore31Skeleton.Core.Utils.Interfaces;
using NetCore31Skeleton.Web.Services.Interfaces;
using NetCore31Skeleton.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCore31Skeleton.Web.Services
{
    public class UserServices : IUserServices
    {
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpAccessor;
        private readonly IHttpClientHelperFactory httpClientHelper;

        public UserServices(IMapper mapper, IHttpContextAccessor httpAccessor, IHttpClientHelperFactory httpClientHelper)
        {
            this.mapper = mapper;
            this.httpAccessor = httpAccessor;
            this.httpClientHelper = httpClientHelper;
        }

        public bool Login(LoginVM loginVM)
        {
            var loginDto = mapper.Map<LoginDto>(loginVM);

            var httpClient = httpClientHelper.Create<LoginDto,IDataResult<string>>();
            try
            {
                var result = httpClient.Post(ConfigurationManager.AppSettings["ApiUrl"], "auth/login", loginDto);
                if (result.IsSuccess)
                {
                    var token = result.Data;

                    httpAccessor.HttpContext.Session.SetString("token", token);
                    return true;
                }
                return false;
            }
            catch(Exception exp)
            {
                return false;
            }
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
