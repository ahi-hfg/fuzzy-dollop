using FluentValidation;

namespace FuzzyDollop.Application.UseCases.RegisterTrainer.V1
{
    public class RegisterTrainerCommandValidator : AbstractValidator<RegisterTrainerCommand>
    {
        public RegisterTrainerCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}