using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class ProductDto : BaseEntityDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double? Price { get; set; }

        public int? StockQuantity { get; set; }

        public int? IdTypeProduct { get; set; }

        public int? IdCategory { get; set; }
    }
}