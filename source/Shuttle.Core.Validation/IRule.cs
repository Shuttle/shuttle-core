using System;

namespace Shuttle.Core.Validation
{
    public interface IRule<T> 
    {
        RuleMessage Message { get; }

        void SetMessageArguments(params string[] args);
        void SetException(Exception ex);

        bool IsBrokenBy(T item);
    }
}
