using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategory
    {
        private readonly NikeContext _context;

        public CategoryRepository(NikeContext context) : base(context)
        {
            _context = context;
        }
    }
}