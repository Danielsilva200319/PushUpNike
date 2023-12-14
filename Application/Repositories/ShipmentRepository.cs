using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class ShipmentRepository : GenericRepository<Shipment>, IShipment
    {
        private readonly NikeContext _context;

        public ShipmentRepository(NikeContext context) : base(context)
        {
            _context = context;
        }
    }
}