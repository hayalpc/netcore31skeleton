using System.ComponentModel.DataAnnotations;

namespace NetCore31Skeleton.Web.ViewModels
{
    public class ErrorVM
    {
        [Display(Name = "VM.Title")]
        public string Title { get; set; }
        [Display(Name = "VM.Message")]
        public string Message { get; set; }
    }
}
