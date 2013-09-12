using System.Collections.Generic;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Validation
{
    public interface IRuleCollection<T>
    {
        int Count { get; }

        IList<RuleMessage> Messages { get; }
        bool IsEmpty { get; }
        IRuleCollection<T> BrokenBy(T item);
        bool IsBrokenBy(T item);
        
        IResult ToResult();
        
        void AssignTo(IList<IRule<T>> list);
        void Enforce(T item);
    }
}
