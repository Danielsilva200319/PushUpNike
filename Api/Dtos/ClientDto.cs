using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class ClientDto : BaseEntityDto
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string Comment { get; set; }

        public int? IdAddress { get; set; }

        public int? IdPhone { get; set; }

        public int? IdCity { get; set; }

        public int? IdDiscount { get; set; }

        public int? IdTypeClient { get; set; }
    }
}