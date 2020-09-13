using System;
using System.ComponentModel.DataAnnotations;

namespace NetCore31Skeleton.WebApi.Core.Dtos
{
    public class CategoryDto
    {
        public long Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
