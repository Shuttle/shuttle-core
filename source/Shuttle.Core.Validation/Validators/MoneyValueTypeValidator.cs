using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Validation
{
    public class MoneyValueTypeValidator : IValueTypeValidator
    {
        public static string TypeName = "Money";

        public string Type
        {
            get { return TypeName; }
        }

        public IResult Validate(string value)
        {
            var result = Result.Create();

            decimal d;

            if (!decimal.TryParse(value, out d))
            {
                result.AddFailureMessage("Please enter a decimal value.");
            }

            return result;
        }
    }
}
