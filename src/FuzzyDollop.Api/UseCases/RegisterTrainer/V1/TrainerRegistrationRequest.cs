using System;

namespace FuzzyDollop.Api.UseCases.RegisterTrainer.V1
{
    public record TrainerRegistrationRequest(
        Guid Id,
        string FirstName,
        string LastName);
}