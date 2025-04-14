using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Repositories.Interface;
using WebApplication.Repositories.Repository;

namespace WebApplication.Repositories
{
    public static class DependencyInjectionRepository
    {
        public static IServiceCollection AddDependencyInjectionRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
