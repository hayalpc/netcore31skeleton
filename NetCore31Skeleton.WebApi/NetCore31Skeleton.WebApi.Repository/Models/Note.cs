using NetCore31Skeleton.Library.Repository;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore31Skeleton.WebApi.Repository.Models
{
    [Table("Note", Schema = "dbo")]
    public class Note : GenericModel<long>
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public DateTime CreateTime { get; set; }

        public Category Category { get; set; }
    }
}
