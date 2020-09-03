using NetCore31Skeleton.Library.Repository;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore31Skeleton.WebApi.Repository.Models
{
    [Table("Log", Schema ="dbo")]
    public class Log : GenericModel<long>
    {
        [Key]
        public long Id { get; set; }
        public string Application { get; set; }
        public DateTime Logged { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Logger { get; set; }
        public string Callsite { get; set; }
        public string Exception { get; set; }
        [StringLength(128)]
        public string TraceId { get; set; }
        [StringLength(128)]
        public string SessionId { get; set; }
    }
}
