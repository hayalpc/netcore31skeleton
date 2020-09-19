using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore31Skeleton.WebApi.Repository.Models
{
    public class UserDto
    {
        public string Name { get; set; }
        
        public string Surname { get; set; }
        
        public string Email { get; set; }

        public string Username { get; set; }
        
        public string Password { get; set; }

        public DateTime LastLoginTime { get; set; }


        public virtual string FullName
        {
            get
            {
                return Name + " " + Surname;
            }
        }
    }
}
