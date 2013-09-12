namespace Shuttle.Core.Data
{
    public interface IUpdateBuilderFor
    {
        IExecutableQuery HasValue<T>(T value);
    }
}