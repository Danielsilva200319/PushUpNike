using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class StatusDto : BaseEntityDto
    {
        public string EntityName { get; set; }

        public string Status1 { get; set; }

        public string Description { get; set; }
    }
}