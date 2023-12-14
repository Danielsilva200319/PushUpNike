using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class PostalCodeDto : BaseEntityDto
    {
        public string PostalCode1 { get; set; }

        public int? IdCity { get; set; }
    }
}