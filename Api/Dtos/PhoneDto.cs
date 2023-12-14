using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class PhoneDto : BaseEntityDto
    {
        public string Phone1 { get; set; }

        public string TypePhone { get; set; }
    }
}