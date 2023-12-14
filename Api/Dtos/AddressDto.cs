using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class AddressDto : BaseEntityDto
    {
        public string Address1 { get; set; }

        public int? IdPostalCode { get; set; }

        public int? IdCity { get; set; }
    }
}