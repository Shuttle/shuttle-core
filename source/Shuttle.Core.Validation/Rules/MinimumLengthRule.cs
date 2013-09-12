using System;

namespace Shuttle.Core.Validation
{
    public class MinimumLengthRule : Rule
    {
        public MinimumLengthRule(int minimumLength)
            : base(ValidationResources.MinimumLengthRule,
                   (item, rule) =>
                       {
                           var value = Convert.ToString(item);

                           var result = value.Length < minimumLength;

                           if (result)
                           {
                               rule.SetMessageArguments(Convert.ToString(minimumLength));
                           }

                           return result;
                       })
        {
        }
    }
}