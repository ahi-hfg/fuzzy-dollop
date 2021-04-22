using FluentValidation;
using FuzzyDollop.Application.Common;
using Microsoft.Extensions.DependencyInjection;

namespace FuzzyDollop.Api.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            AssemblyScanner
                .FindValidatorsInAssembly(typeof(IResult).Assembly)
                .ForEach(validator => services.AddScoped(validator.InterfaceType, validator.ValidatorType));

            return services;
        }
    }
}