using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class PostalCodeRepository : GenericRepository<Postalcode>, IPostalCode
    {
        private readonly NikeContext _context;

        public PostalCodeRepository(NikeContext context) : base(context)
        {
            _context = context;
        }
    }
}