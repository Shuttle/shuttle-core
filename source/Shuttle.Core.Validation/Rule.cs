using System;

namespace Shuttle.Core.Validation
{
    public delegate bool RulePredicate<T>(T item, IRule<T> rule);

    public class Rule<T> : IRule<T> where T : class
    {
        private readonly RulePredicate<T> predicate;

        private string rawMessage;

        public Rule(string message, RulePredicate<T> predicate)
        {
            RawMessage = message;

            this.predicate = predicate;
        }

        protected string RawMessage
        {
            get { return rawMessage; }
            set
            {
                rawMessage = value;
                Message = new RuleMessage(rawMessage);
            }
        }

        public bool IsBrokenBy(T item)
        {
            return predicate(item, this);
        }

        public RuleMessage Message { get; protected set; }

        public void SetMessageArguments(params string[] args)
        {
            Message.Message = string.Format(RawMessage, args);
        }

        public void SetException(Exception ex)
        {
            Message.Message = ex.Message;
        }
    }

    public class Rule : Rule<object>
    {
        public Rule(string message, RulePredicate<object> predicate) : base(message, predicate)
        {
        }

        public static IRuleCollectionBuilder With()
        {
            return new RuleCollectionBuilder();
        }
    }
}
