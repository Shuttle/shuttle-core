using System;
using System.Collections.Generic;

namespace Shuttle.Core.Infrastructure
{
    public interface IResult
    {
        List<ResultMessage> SuccessMessages { get; }
        List<ResultMessage> FailureMessages { get; }
        bool OK { get; }
        bool Aborted { get; }
        bool HasMessages { get; }
        bool HasFailureMessages { get; }
        bool HasSuccessMessages { get; }
        void SetAbort();
        void Merge(IResult result);
        string ToString();
        void AddFailureMessage(ResultMessage message);
        void AddFailureMessage(string message);
        void AddFailureMessages(params string[] messages);
        void AddFailureMessages(IEnumerable<string> messages);
        void AddSuccessMessage(ResultMessage message);
        void AddSuccessMessage(string message);
        void AddSuccessMessages(params string[] messages);
        void AddSuccessMessages(IEnumerable<string> messages);
        void AddException(Exception ex);
    }

    public interface IResult<out TValue> : IResult
    {
        TValue Value { get; }
    }
}
