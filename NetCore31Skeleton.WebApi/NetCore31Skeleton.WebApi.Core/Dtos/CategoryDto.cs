using System;

namespace NetCore31Skeleton.WebApi.Core.Dtos
{
    public class CategoryDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
