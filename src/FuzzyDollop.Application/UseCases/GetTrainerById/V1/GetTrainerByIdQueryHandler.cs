using System.Threading;
using System.Threading.Tasks;
using FuzzyDollop.Application.Common;
using FuzzyDollop.Application.UseCases.RegisterTrainer.V1;
using FuzzyDollop.Domain.Entities;
using FuzzyDollop.Domain.Factories;
using FuzzyDollop.Domain.Repositories;
using MediatR;

namespace FuzzyDollop.Application.UseCases.GetTrainerById.V1
{
    public class GetTrainerByIdQueryHandler : IRequestHandler<GetTrainerByIdQuery, IResult>
    {
        private readonly ITrainerRepository _trainerRepository;

        public GetTrainerByIdQueryHandler(
            ITrainerRepository trainerRepository)
        {
            _trainerRepository = trainerRepository;
        }
        
        public async Task<IResult> Handle(GetTrainerByIdQuery query, CancellationToken cancellationToken)
        {
            var trainer = await _trainerRepository.GetAsync(query.TrainerId, cancellationToken);

            return new SuccessResult<Trainer>(trainer);
        }
    }
}