using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetCore31Skeleton.WebApi.Core.Dtos
{
    public class TestDto
    {
        [Required]
        public string Test { get; set; }
    }
}
