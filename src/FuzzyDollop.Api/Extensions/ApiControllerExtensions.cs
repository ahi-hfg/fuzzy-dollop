using Microsoft.Extensions.DependencyInjection;

namespace FuzzyDollop.Api.Extensions
{
    public static class ApiControllerExtensions
    {
        public static IServiceCollection AddApiControllers(this IServiceCollection services)
        {
            services.AddControllers();
            return services;
        }
    }
}

