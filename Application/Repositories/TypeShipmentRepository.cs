using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class TypeShipmentRepository : GenericRepository<Typeshipment>, ITypeShipment
    {
        private readonly NikeContext _context;

        public TypeShipmentRepository(NikeContext context) : base(context)
        {
            _context = context;
        }
    }
}