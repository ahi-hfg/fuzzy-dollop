namespace FuzzyDollop.Application.Common
{
    public record SuccessResult : IResult
    {
        
    }

    public record SuccessResult<TResult>(TResult Result)
        : IResult;
}