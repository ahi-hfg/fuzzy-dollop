using FuzzyDollop.Application.Common;
using FuzzyDollop.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuzzyDollop.Api.UseCases.GetTrainerById.V1
{
    public static class Output
    {
        public static IActionResult For(IResult result) =>
            result switch
            {
                SuccessResult<Trainer> success => new OkObjectResult(success.Result),
                _ => new StatusCodeResult(StatusCodes.Status500InternalServerError)
            };
    }
}