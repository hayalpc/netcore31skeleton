using System.ComponentModel.DataAnnotations;

namespace NetCore31Skeleton.Core.Dtos
{
    public class LoginDto
    {
        [Required,StringLength(32)]
        public string Username { get; set; }

        [Required,StringLength(32)]
        public string Password { get; set; }
    }
}
