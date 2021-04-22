using System;

namespace FuzzyDollop.Api.UseCases.GetTrainerById.V1
{
    public record TrainerDto
        (Guid Id, string FirstName, string LastName);
}