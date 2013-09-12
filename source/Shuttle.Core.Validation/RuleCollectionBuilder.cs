using System.Collections.Generic;

namespace Shuttle.Core.Validation
{
    public class RuleCollectionBuilder : IRuleCollectionBuilder
    {
        private readonly IList<IRule<object>> rules = new List<IRule<object>>();

        public IRuleCollectionBuilder MinimumLength(int minimumLength)
        {
            return Add(new MinimumLengthRule(minimumLength));
        }

        public IRuleCollectionBuilder MaximumLength(int maximumLength)
        {
            return Add(new MaximumLengthRule(maximumLength));
        }

        public IRuleCollectionBuilder Required()
        {
            return Add(new RequiredRule());
        }

        public IRuleCollectionBuilder Decimal()
        {
            return Add(new DecimalRule());
        }

        public IRuleCollectionBuilder Integer()
        {
            return Add(new IntegerRule());
        }

        public IRuleCollectionBuilder Custom(IRule<object> rule)
        {
            return Add(rule);
        }

        public IRuleCollectionBuilder DateTime()
        {
            return Add(new DateTimeRule());
        }

        public IRuleCollection<object> Create()
        {
            return new RuleCollection<object>(rules);
        }

        private IRuleCollectionBuilder Add(IRule<object> rule)
        {
            rules.Add(rule);

            return this;
        }
    }
}