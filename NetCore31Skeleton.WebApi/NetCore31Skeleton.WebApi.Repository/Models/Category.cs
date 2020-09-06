using NetCore31Skeleton.Library.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore31Skeleton.WebApi.Repository.Models
{
    [Table("Category",Schema ="dbo")]
    public class Category: GenericModel<long>
    {
        [Key]
        public long Id { get; set; }

        [StringLength(128), Required]
        public string Title { get; set; }

        [StringLength(512), Required]
        public string Description { get; set; }

        public List<Note> Notes { get; set; }
    }
}
