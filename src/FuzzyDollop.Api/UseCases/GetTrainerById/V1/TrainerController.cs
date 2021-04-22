using System;
using System.Threading;
using System.Threading.Tasks;
using FuzzyDollop.Api.Common;
using FuzzyDollop.Api.UseCases.RegisterTrainer.V1;
using FuzzyDollop.Application.UseCases.GetTrainerById.V1;
using FuzzyDollop.Application.UseCases.RegisterTrainer.V1;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuzzyDollop.Api.UseCases.GetTrainerById.V1
{
    [ApiController]
    [Route("trainers")]
    public class TrainerController
    {
        private readonly IMediator _mediator;

        public TrainerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{trainerId}")]
        [ProducesResponseType(typeof(TrainerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(FaultDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterAsync(
            Guid trainerId,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetTrainerByIdQuery(trainerId), cancellationToken);
            return Output.For(result);
        }
    }
}