using FuzzyDollop.Api.UseCases.RegisterTrainer.V1;
using Microsoft.Extensions.DependencyInjection;

namespace FuzzyDollop.Api.Extensions
{
    public static class UseCaseExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services) =>
            services
                .AddRegisterTrainerUseCase();
    }
}