using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Validation
{
    public interface IRuleResult
    {
        bool OK { get; }
        ResultMessage RootMessage { get; }
        IResult ToResult();
    }
}
