using FuzzyDollop.Domain.Factories;
using FuzzyDollop.Domain.Repositories;
using FuzzyDollop.Infrastructure.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FuzzyDollop.Api.UseCases.RegisterTrainer.V1
{
    public static class Dependencies
    {
        public static IServiceCollection AddRegisterTrainerUseCase(this IServiceCollection services)
        {
            services.TryAddTransient<ITrainerFactory, TrainerFactory>();
            services.TryAddTransient<ITrainerRepository, TrainerRepository>();
            
            return services;
        }
    }
}