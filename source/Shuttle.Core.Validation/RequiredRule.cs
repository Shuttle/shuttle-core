using System;

namespace Shuttle.Core.Validation
{
    public class RequiredRule : Rule
    {
        public RequiredRule()
            : base(ValidationResources.RequiredRule, (item, rule) => Convert.ToString(item).Length < 1)
        {
        }
    }
}
