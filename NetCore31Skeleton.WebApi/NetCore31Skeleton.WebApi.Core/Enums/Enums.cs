using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NetCore31Skeleton.WebApi.Core
{
    public enum TransStatus
    {
        [Display(Name = "ENUM.NEW")]
        NEW = 1,
        [Display(Name = "ENUM.APPROVED")]
        APPROVED = 2,
        [Display(Name = "ENUM.CHARGED")]
        CHARGED = 3,
        [Display(Name = "ENUM.ERROR")]
        ERROR = 4,
        [Display(Name = "ENUM.TIMEOUT")]
        TIMEOUT = 5,
        [Display(Name = "ENUM.REFUNDED")]
        REFUNDED = 6,
        [Display(Name = "ENUM.UNDEFINED")]
        UNDEFINED = 10,
        [Display(Name = "ENUM.FREE_TRIAL")]
        FREE_TRIAL = 15,
        [Display(Name = "ENUM.INTERNAL_ERROR")]
        INTERNAL_ERROR = 20,
    }

    public enum OperatorId
    {
        [Display(Name = "Turkcell")]
        TURKCELL_ID = 1,
        [Display(Name = "Türk Telekom")]
        TURKTELEKOM_ID = 4,
        [Display(Name = "Vodafone")]
        VODAFONE_ID = 5,
    }
}
