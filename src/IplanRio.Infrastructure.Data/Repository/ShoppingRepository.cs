using IplanRio.Domain.Entities;
using IplanRio.Domain.Interfaces.Repository;
using IplanRio.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace IplanRio.Infrastructure.Data.Repository
{
    public class ShoppingRepository : BaseRepository<Shopping>, IShoppingRepository
    {
        private readonly ContextIplanRio _context;

        public ShoppingRepository(ContextIplanRio context)
            : base(context)
        {
            _context = context;
        }
    }
}
