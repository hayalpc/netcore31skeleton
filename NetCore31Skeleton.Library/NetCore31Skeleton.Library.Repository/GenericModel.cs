using NetCore31Skeleton.Library.Repository.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore31Skeleton.Library.Repository
{
    public abstract class GenericModel<Ttype> : IGenericModel<Ttype>
    {
        [Key]
        public Ttype Id { get; set; }
    }
}
