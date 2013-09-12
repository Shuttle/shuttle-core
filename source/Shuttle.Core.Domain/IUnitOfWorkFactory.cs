namespace Shuttle.Core.Domain
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Current { get; set; }
        IUnitOfWork Create();
    }
}