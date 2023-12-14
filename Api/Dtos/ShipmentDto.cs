using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class ShipmentDto : BaseEntityDto
    {
        public DateOnly? ShipmentDate { get; set; }

        public DateOnly? EstimatedArrival { get; set; }

        public DateOnly? ActualArrival { get; set; }

        public int? IdAddress { get; set; }

        public int? IdStatus { get; set; }

        public int? IdTypeShipment { get; set; }
    }
}