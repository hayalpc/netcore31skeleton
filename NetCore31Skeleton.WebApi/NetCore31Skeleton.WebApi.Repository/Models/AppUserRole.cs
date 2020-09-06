using NetCore31Skeleton.Library.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore31Skeleton.WebApi.Repository.Models
{
    [Table("AppUserRole", Schema = "dbo")]
    public class AppUserRole : GenericModel<int>
    {
        public int AppUserId { get; set; }
        public int AppRoleId { get; set; }

        public AppUser AppUser { get; set; } 
        public AppRole AppRole { get; set; }
    }
}
