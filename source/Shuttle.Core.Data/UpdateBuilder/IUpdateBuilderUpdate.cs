namespace Shuttle.Core.Data
{
    public interface IUpdateBuilderUpdate
    {
        IUpdateBuilder ToValue<T>(T value);
    }
}