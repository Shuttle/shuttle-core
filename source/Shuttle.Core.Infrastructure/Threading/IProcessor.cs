namespace Shuttle.Core.Infrastructure
{
    public interface IProcessor
    {
        void Execute(IActiveState state);
    }
}