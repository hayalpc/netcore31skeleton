using NetCore31Skeleton.Core.Dtos;
using NetCore31Skeleton.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore31Skeleton.Web.Services.Interfaces
{
    public interface IUserServices
    {
        bool Login(LoginVM loginVM);

        void Logout();
    }
}
