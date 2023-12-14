using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class DiscountDto : BaseEntityDto
    {
        public string Discount1 { get; set; }

        public string Description { get; set; }

        public double? Percentage { get; set; }

        public DateOnly? StartDate { get; set; }

        public DateOnly? EndDate { get; set; }

        public int? IdStatus { get; set; }
    }
}