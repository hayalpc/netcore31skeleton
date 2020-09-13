using NetCore31Skeleton.Library.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore31Skeleton.WebApi.Repository.Models
{
    [Table("AppUser", Schema = "dbo")]
    public class AppUser : GenericModel<int>
    {
        [StringLength(32), Required]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
        
        [StringLength(32), Required]
        [Column(TypeName = "varchar")]
        public string Surname { get; set; }
        
        [StringLength(64), Required]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }

        [StringLength(32), Required]
        [Column(TypeName = "varchar")]
        public string Username { get; set; }
        
        [StringLength(128), Required]
        [Column(TypeName = "varchar")]
        public string Password { get; set; }

        public DateTime LastLoginTime { get; set; }

        public virtual List<AppUserRole> AppUserRoles { get; set; }

        public virtual string FullName
        {
            get
            {
                return Name + " " + Surname;
            }
        }
    }
}
