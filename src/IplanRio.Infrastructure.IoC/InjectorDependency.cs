using IplanRio.Application.Interfaces;
using IplanRio.Application.Services;
using IplanRio.Domain.Interfaces.Repository;
using IplanRio.Domain.Interfaces.Services;
using IplanRio.Domain.Services;
using IplanRio.Infrastructure.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace IplanRio.Infrastructure.IoC
{
    public class InjectorDependency
    {
        public static void Register(IServiceCollection container)
        {
            // Application

            container.AddScoped(typeof(IBaseAppService<>), typeof(BaseAppService<>));
            container.AddScoped<IShoppingAppService, ShoppingAppService>();

            // Domain

            container.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            container.AddScoped<IShoppingService, ShoppingService>();

            // Infrastructure

            container.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            container.AddScoped<IShoppingRepository, ShoppingRepository>();
        }
    }
}
