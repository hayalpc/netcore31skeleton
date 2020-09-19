using NetCore31Skeleton.WebApi.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore31Skeleton.Core.Dtos
{
    public class SessionDto
    {

        public UserDto User { get; set; }
        public string Roles { get; set; }
    }
}
