using System.Collections.Generic;

namespace FuzzyDollop.Application.Common
{
    public record ErrorResult : IResult
    {
        public IEnumerable<string> Errors { get; set; }        
    }
}