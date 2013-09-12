using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Validation
{
    public class RuleResult : IRuleResult
    {
        public RuleResult(ResultMessage rootMessage)
        {
            RootMessage = rootMessage;
        }

        public RuleResult() : this (null)
        {
        }

        public bool OK
        {
            get { return RootMessage == null; }
        }

        public ResultMessage RootMessage { get; private set; }
        
        public IResult ToResult()
        {
            var result = Result.Create();

            if (!OK)
            {
                result.AddFailureMessage(RootMessage);
            }

            return result;
        }
    }
}
