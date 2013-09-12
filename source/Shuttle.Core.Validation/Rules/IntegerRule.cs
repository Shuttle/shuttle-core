using System;

namespace Shuttle.Core.Validation
{
    public class IntegerRule : Rule
    {
        public IntegerRule()
            : base(ValidationResources.IntegerRule,
                   (item, rule) =>
                       {
                           int i;

                           return !int.TryParse(Convert.ToString(item), out i);
                       })
        {
        }
    }
}