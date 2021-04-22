using System;
using FuzzyDollop.Application.Common;
using MediatR;

namespace FuzzyDollop.Application.UseCases.RegisterTrainer.V1
{
    public record RegisterTrainerCommand
        (Guid Id, string FirstName, string LastName)
        : IRequest<IResult>;
}
