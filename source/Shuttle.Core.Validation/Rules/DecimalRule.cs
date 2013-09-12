using System;

namespace Shuttle.Core.Validation
{
    public class DecimalRule : Rule
    {
        public DecimalRule()
            : base(ValidationResources.DecimalRule,
                   (item, rule) =>
                       {
                           decimal dec;

                           return !decimal.TryParse(Convert.ToString(item), out dec);
                       })
        {
        }
    }
}