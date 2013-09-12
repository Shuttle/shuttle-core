using System;

namespace Shuttle.Core.Validation
{
    public class MaximumLengthRule : Rule
    {
        public MaximumLengthRule(int maximumLength)
            : base(ValidationResources.MaximumLengthRule,
                   (item, rule) =>
                       {
                           var value = Convert.ToString(item);

                           var result = value.Length > maximumLength;

                           if (result)
                           {
                               rule.SetMessageArguments(Convert.ToString(maximumLength));
                           }

                           return result;
                       })
        {
        }
    }
}