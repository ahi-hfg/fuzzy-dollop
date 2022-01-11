using FuzzyDollop.Application.Common;
using FuzzyDollop.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuzzyDollop.Api.UseCases.GetTrainerById.V1
{
    public static class Output
    {
        public static IActionResult For(IAppResult result) =>
            result switch
            {
                SuccessResult<Trainer> success => new OkObjectResult(success.Result),
                EntityNotFoundResult => new NotFoundResult(),
                _ => new StatusCodeResult(StatusCodes.Status500InternalServerError)
            };
    }
}