using System;

namespace Shuttle.Core.Validation
{
    public class DateTimeRule : Rule
    {
        public DateTimeRule()
            : base(ValidationResources.DateTimeRule,
                   (item, rule) =>
                       {
                           DateTime dt;

                           return !DateTime.TryParse(Convert.ToString(item), out dt);
                       })
        {
        }
    }
}