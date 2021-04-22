using FuzzyDollop.Domain.Repositories;
using FuzzyDollop.Infrastructure.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FuzzyDollop.Api.UseCases.GetTrainerById.V1
{
    public static class Dependencies
    {
        public static IServiceCollection AddRegisterTrainerUseCase(this IServiceCollection services)
        {
            services.TryAddTransient<ITrainerRepository, TrainerRepository>();
            
            return services;
        }
    }
}