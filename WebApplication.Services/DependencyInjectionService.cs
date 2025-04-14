using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication.Services.Interface;
using WebApplication.Services.Service;

namespace WebApplication.Services
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddDependencyInjectionService(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
