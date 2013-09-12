using System;
using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Validation
{
    public class IntegerValueTypeValidator : IValueTypeValidator
    {
        public string Type
        {
            get { return "Integer"; }
        }

        public IResult Validate(string value)
        {
            var result = Result.Create();

            int i;

            if (!int.TryParse(value, out i))
            {
                result.AddFailureMessage("Please enter an integer value.");
            }

            return result;
        }
    }
}
