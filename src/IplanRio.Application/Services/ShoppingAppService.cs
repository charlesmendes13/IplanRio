using IplanRio.Application.Interfaces;
using IplanRio.Domain.Entities;
using IplanRio.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace IplanRio.Application.Services
{
    public class ShoppingAppService : BaseAppService<Shopping>, IShoppingAppService
    {
        public readonly IShoppingService _shoppingService;

        public ShoppingAppService(IShoppingService shoppingService)
            : base(shoppingService)
        {
            _shoppingService = shoppingService;
        }
    }
}
