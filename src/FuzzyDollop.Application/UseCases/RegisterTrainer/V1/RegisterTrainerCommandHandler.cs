using System.Threading;
using System.Threading.Tasks;
using FuzzyDollop.Application.Common;
using FuzzyDollop.Domain.Factories;
using FuzzyDollop.Domain.Repositories;
using MediatR;

namespace FuzzyDollop.Application.UseCases.RegisterTrainer.V1
{
    public class RegisterTrainerCommandHandler : IRequestHandler<RegisterTrainerCommand, IResult>
    {
        private readonly ITrainerFactory _trainerFactory;
        private readonly ITrainerRepository _trainerRepository;

        public RegisterTrainerCommandHandler(
            ITrainerFactory trainerFactory,
            ITrainerRepository trainerRepository)
        {
            _trainerFactory = trainerFactory;
            _trainerRepository = trainerRepository;
        }
        
        public async Task<IResult> Handle(RegisterTrainerCommand request, CancellationToken cancellationToken)
        {
            var trainer = _trainerFactory.Create(request.Id, request.FirstName, request.LastName);
            await _trainerRepository.AddAsync(trainer, cancellationToken);
            await _trainerRepository.CommitAsync(cancellationToken);

            return new SuccessResult();
        }
    }
}