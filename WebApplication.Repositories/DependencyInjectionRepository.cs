using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Repositories
{
    public static class DependencyInjectionRepository
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            return services;
        }
    }
}
