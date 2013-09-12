using System.Collections.Generic;

namespace Shuttle.Core.Infrastructure
{
    public interface IEnumerableActions<T>
    {
        void VisitAllItemsUsing(IVisitor<T> visitor);
        Result GetResultOfVisitingAllItemsWith<Result>(IValueReturningVisitor<Result, T> visitor);
        IEnumerable<T> AllMatching(Specification<T> specification);
    }
}
