using NetCore31Skeleton.Library.Repository.Interfaces;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace NetCore31Skeleton.Library.Repository
{
    public abstract class GenericModel<Ttype> : IGenericModel<Ttype>
        where Ttype : struct
    {
        [Key]
        public Ttype Id { get; set; }

        public DateTime CreateTime { get; set; } = DateTime.Now;
        public int CreateUserId { get; set; } = -1;

        public DateTime? UpdateTime { get; set; }
        public int? UpdateUserId { get; set; }

        public Status StatusId { get; set; } = Status.Active;

        public string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
