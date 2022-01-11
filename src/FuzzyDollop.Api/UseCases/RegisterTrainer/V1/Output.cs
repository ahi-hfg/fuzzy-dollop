using FuzzyDollop.Application.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuzzyDollop.Api.UseCases.RegisterTrainer.V1
{
    public static class Output
    {
        public static IActionResult For(IAppResult result) =>
            result switch
            {
                SuccessResult => new NoContentResult(),
                ErrorResult => new BadRequestResult(),
                _ => new StatusCodeResult(StatusCodes.Status500InternalServerError)
            };
    }
}