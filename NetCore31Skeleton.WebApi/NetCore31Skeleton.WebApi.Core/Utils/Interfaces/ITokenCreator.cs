using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore31Skeleton.WebApi.Core.Utils.Interfaces
{
    public interface ITokenCreator
    {
        string CreateToken();
    }
}
