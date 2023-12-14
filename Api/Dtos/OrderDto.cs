using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class OrderDto : BaseEntityDto
    {
        public DateOnly? OrderDate { get; set; }

        public int? TotalAmount { get; set; }

        public int? IdClient { get; set; }

        public int? IdTypeOrder { get; set; }

        public int? IdShipment { get; set; }

        public int? IdPayment { get; set; }

        public int? IdStatus { get; set; }

        public int? IdProduct { get; set; }
    }
}