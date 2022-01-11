namespace FuzzyDollop.Application.Common
{
    public record SuccessResult : IAppResult
    {
        
    }

    public record SuccessResult<TResult>(TResult Result)
        : IAppResult;
}