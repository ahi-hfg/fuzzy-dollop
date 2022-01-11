using System.Collections.Generic;

namespace FuzzyDollop.Application.Common
{
    public record ErrorResult : IAppResult
    {
        public IEnumerable<string> Errors { get; set; }        
    }
}