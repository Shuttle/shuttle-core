using Shuttle.Core.Infrastructure;

namespace Shuttle.Core.Validation
{
    public interface IValueTypeValidator
    {
        string Type{ get; }
        IResult Validate(string value);
    }
}
