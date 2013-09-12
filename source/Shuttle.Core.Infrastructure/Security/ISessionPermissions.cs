namespace Shuttle.Core.Infrastructure
{
    public interface ISessionPermissions
    {
        IPermissionCollection Permissions { get; }
    }
}
