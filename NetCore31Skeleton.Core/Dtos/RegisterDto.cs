using System.ComponentModel.DataAnnotations;

namespace NetCore31Skeleton.Core.Dtos
{
    public class RegisterDto
    {
        [StringLength(32), Required]
        public string Name { get; set; }

        [StringLength(32), Required]
        public string Surname { get; set; }

        [StringLength(64), Required]
        public string Email { get; set; }

        [StringLength(32), Required]
        public string Username { get; set; }

        [StringLength(128), Required]
        public string Password { get; set; }
    }
}
