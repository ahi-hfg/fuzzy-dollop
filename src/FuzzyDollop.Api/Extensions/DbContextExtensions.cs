using FuzzyDollop.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FuzzyDollop.Api.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddInMemoryDatabase(this IServiceCollection services) =>
            services.AddDbContext<DexContext>(options => options.UseInMemoryDatabase("Dex"));
    }
}