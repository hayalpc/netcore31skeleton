using NetCore31Skeleton.Library.Repository;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore31Skeleton.WebApi.Repository.Models
{
    [Table("Note", Schema = "dbo")]
    public class Note : GenericModel<long>
    {
        [Required]
        [StringLength(128)]
        public string Title { get; set; }

        [Required]
        [StringLength(512)]
        public string Description { get; set; }

        [Required]
        public long CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
