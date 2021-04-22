using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace FuzzyDollop.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FuzzyDollop.Api", Version = "v1" });
            });
    }
}