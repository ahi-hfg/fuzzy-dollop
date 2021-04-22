using FuzzyDollop.Api.Common;
using FuzzyDollop.Application.Common;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FuzzyDollop.Api.Extensions
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services) =>
            services
                .AddMediatR(typeof(IResult).Assembly)
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
    }
}