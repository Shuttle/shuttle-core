namespace Shuttle.Core.Validation
{
    public interface IValueTypeValidatorProvider
    {
        IValueTypeValidator Get(string type);
        bool Has(string type);
    }
}
