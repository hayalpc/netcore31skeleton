using System.ComponentModel.DataAnnotations;

namespace NetCore31Skeleton.Web.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Kullanıcı Adı zorunludur."), StringLength(32)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur."), StringLength(32)]
        public string Password { get; set; }

        public bool HasErrors { get; set; } = false;
        public ErrorVM Error { get; set; }
    }
}
