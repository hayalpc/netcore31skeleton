using System;

namespace NetCore31Skeleton.Library.Repository.Interfaces
{
    public interface IGenericModel<Ttype>
        where Ttype : struct
    {
        string ToString();

        Ttype Id { get; set; }

        DateTime CreateTime { get; set; }
        int CreateUserId { get; set; }

        DateTime? UpdateTime { get; set; }
        int? UpdateUserId { get; set; }

        Status StatusId { get; set; }
    }
}