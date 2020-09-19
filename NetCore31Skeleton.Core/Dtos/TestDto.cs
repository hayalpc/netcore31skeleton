using System.ComponentModel.DataAnnotations;

namespace NetCore31Skeleton.Core.Dtos
{
    public class TestDto
    {
        [Required]
        public string Test { get; set; }
    }
}
