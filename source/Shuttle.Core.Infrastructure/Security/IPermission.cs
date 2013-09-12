namespace Shuttle.Core.Infrastructure
{
    public interface IPermission : ISpecification<IPermissionCollection>
    {
        string Identifier { get; set; }
        string Description { get; set; }
    }
}
