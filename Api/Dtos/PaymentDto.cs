using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class PaymentDto : BaseEntityDto
    {
        public int? Amount { get; set; }

        public DateOnly? PaymentDate { get; set; }

        public int? IdClient { get; set; }

        public int? IdTypePayment { get; set; }

        public int? IdStatus { get; set; }
    }
}