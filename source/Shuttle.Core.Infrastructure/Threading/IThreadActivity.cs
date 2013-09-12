namespace Shuttle.Core.Infrastructure
{
    public interface IThreadActivity
    {
        void Waiting(IActiveState state);
        void Working();
    }
}