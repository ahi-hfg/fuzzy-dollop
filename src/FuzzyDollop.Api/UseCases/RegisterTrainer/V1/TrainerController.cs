using System.Threading;
using System.Threading.Tasks;
using FuzzyDollop.Api.Common;
using FuzzyDollop.Application.UseCases.RegisterTrainer.V1;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuzzyDollop.Api.UseCases.RegisterTrainer.V1
{
    [ApiController]
    [Route("trainers")]
    public class TrainerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrainerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(FaultDto), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterAsync(
            [FromBody] TrainerRegistrationRequest request,
            CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new RegisterTrainerCommand(request.Id, request.FirstName, request.LastName), cancellationToken);
            return Output.For(result);
        }
    }
}
