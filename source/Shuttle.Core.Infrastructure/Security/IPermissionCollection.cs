using System.Collections.Generic;

namespace Shuttle.Core.Infrastructure
{
    public interface IPermissionCollection : IHumaneList<IPermission>
    {
        bool HasAccessToAnyOf(params string[] thesePermissions);
        bool HasAccessToAnyOf(params IPermission[] thesePermissions);
        bool HasAccessToAnyOf(IEnumerable<IPermission> thesePermissions);
        bool HasAccessToAllOf(params string[] thesePermissions);
        bool HasAccessToAllOf(params IPermission[] thesePermissions);
        bool HasAccessToAllOf(IEnumerable<IPermission> thesePermissions);

        bool HasAccessTo(string permission);
        bool HasAccessTo(IPermission permission);
        IPermissionCollection Remove(IPermissionCollection permissions);
        IPermissionCollection AssignDescriptionsUsing(IPermissionCollection permissions);
    }
}
