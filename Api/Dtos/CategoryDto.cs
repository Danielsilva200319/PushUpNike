using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class CategoryDto : BaseEntityDto
    {
        public string Category1 { get; set; }

        public string Description { get; set; }
    }
}