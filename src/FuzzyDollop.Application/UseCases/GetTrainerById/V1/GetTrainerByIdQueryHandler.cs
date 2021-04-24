using System.Threading;
using System.Threading.Tasks;
using FuzzyDollop.Application.Common;
using FuzzyDollop.Domain.Entities;
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
            if (trainer == null)
            {
                return new EntityNotFoundResult();
            }

            return new SuccessResult<Trainer>(trainer);
        }
    }
}