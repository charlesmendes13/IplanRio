using IplanRio.Domain.Entities;
using IplanRio.Domain.Interfaces.Repository;
using IplanRio.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace IplanRio.Domain.Services
{
    public class ShoppingService : BaseService<Shopping>, IShoppingService
    {
        private readonly IShoppingRepository _shoppingRepository;

        public ShoppingService(IShoppingRepository shoppingRepository)
            : base(shoppingRepository)
        {
            _shoppingRepository = shoppingRepository;
        }
    }
}