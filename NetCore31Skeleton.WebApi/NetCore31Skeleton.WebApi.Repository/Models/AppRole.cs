using NetCore31Skeleton.Library.Repository;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore31Skeleton.WebApi.Repository.Models
{
    [Table("AppRole", Schema = "dbo")]
    public class AppRole : GenericModel<int>
    {
        [StringLength(32),Required]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        public virtual List<AppUserRole> AppUserRoles { get; set; }
    }
}
