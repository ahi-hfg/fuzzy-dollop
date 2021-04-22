using System;
using FuzzyDollop.Application.Common;
using MediatR;

namespace FuzzyDollop.Application.UseCases.GetTrainerById.V1
{
    public record GetTrainerByIdQuery
        (Guid TrainerId)
        : IRequest<IResult>;
}
