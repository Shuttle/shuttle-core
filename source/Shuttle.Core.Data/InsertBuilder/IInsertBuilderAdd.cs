namespace Shuttle.Core.Data
{
    public interface IInsertBuilderAdd
    {
        IInsertBuilder WithValue<T>(T value);
    }
}