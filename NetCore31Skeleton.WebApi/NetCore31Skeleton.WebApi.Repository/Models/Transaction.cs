using NetCore31Skeleton.Library.Repository;
using NetCore31Skeleton.WebApi.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore31Skeleton.WebApi.Repository.Models
{
    [Table("Transaction", Schema = "dbo")]
    public class Transaction : GenericModel<long>
    {
        [Required]
        public long MerchantId { get; set; }

        [Required]
        public long ServiceId { get; set; }

        [Required]
        public long OperatorId { get; set; }

        [StringLength(16),Required]
        [Column(TypeName = "varchar")]
        public string Msisdn { get; set; }

        [Column(TypeName = "decimal(8,2)"),Required]
        public decimal Amount { get; set; }

        [Required]
        public TransStatus Status { get; set; }

        public DateTime? ChargeDate { get; set; } = null;

        [StringLength(64),Required]
        [Column(TypeName = "varchar")]
        public string Item { get; set; }

        public DateTime? RefundDate { get; set; } = null;

        [Column(TypeName = "varchar")]
        [StringLength(64)]
        public string RefundSource { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(64)]
        public string OperatorTransId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(64)]
        public string OrderId { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(32)]
        public string UserIp { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(32)]
        public string Channel { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(128)]
        public string Error { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(256)]
        public string ErrDesc { get; set; }

        public long? SubId { get; set; } = 0;

        public Guid Guid { get; set; } = Guid.NewGuid();

    }
}
