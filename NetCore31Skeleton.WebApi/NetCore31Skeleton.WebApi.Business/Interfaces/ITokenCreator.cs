using NetCore31Skeleton.WebApi.Repository.Models;
using System.Collections.Generic;

namespace NetCore31Skeleton.WebApi.Business.Interfaces
{
    public interface ITokenCreator
    {
        string CreateToken(AppUser appUser, List<AppRole> appUserRoles);
    }
}
