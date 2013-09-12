using System;
using System.Collections.Generic;
using System.Linq;

namespace Shuttle.Core.Infrastructure
{
    public class PermissionCollection : HumaneList<IPermission>, IPermissionCollection
    {
        public PermissionCollection()
        {
        }

        public PermissionCollection(IEnumerable<IPermission> permissions)
            : base(permissions)
        {
        }

        public bool HasAccessToAnyOf(params IPermission[] thesePermissions)
        {
            Guard.AgainstNull(thesePermissions, "thesePermissions");

            return HasAccessToAnyOf((IEnumerable<IPermission>) thesePermissions);
        }

        public bool HasAccessToAnyOf(IEnumerable<IPermission> thesePermissions)
        {
            Guard.AgainstNull(thesePermissions, "thesePermissions");

            if ((thesePermissions == null) || (thesePermissions.Count() == 0))
            {
                return true;
            }

            foreach (var permission in thesePermissions)
            {
                if (Exists(permission.Equals))
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasAccessToAnyOf(params string[] thesePermissions)
        {
            Guard.AgainstNull(thesePermissions, "thesePermissions");

            return
                HasAccessToAnyOf(
                    new List<string>(thesePermissions).ConvertAll(s => new Permission(s)).Cast<IPermission>());
        }

        public bool HasAccessToAllOf(params IPermission[] thesePermissions)
        {
            Guard.AgainstNull(thesePermissions, "thesePermissions");

            return HasAccessToAllOf((IEnumerable<IPermission>) thesePermissions);
        }

        public bool HasAccessToAllOf(IEnumerable<IPermission> thesePermissions)
        {
            Guard.AgainstNull(thesePermissions, "thesePermissions");

            if ((thesePermissions == null) || (thesePermissions.Count() == 0))
            {
                return true;
            }

            foreach (var permission in thesePermissions)
            {
                if (!Exists(permission.Equals))
                {
                    return false;
                }
            }

            return true;
        }

        public bool HasAccessToAllOf(params string[] thesePermissions)
        {
            Guard.AgainstNull(thesePermissions, "thesePermissions");

            return
                HasAccessToAllOf(
                    new List<string>(thesePermissions).ConvertAll(s => new Permission(s)).Cast<IPermission>());
        }

        public bool HasAccessTo(string permission)
        {
            Guard.AgainstNull(permission, "permission");

            return HasAccessTo((IPermission) new Permission(permission));
        }

        public bool HasAccessTo(IPermission permission)
        {
            Guard.AgainstNull(permission, "permission");

            return Exists(permission.Equals);
        }

        public IPermissionCollection Remove(IPermissionCollection permissions)
        {
            var result = new PermissionCollection();

            foreach (var permission in this)
            {
                if (!permissions.HasAccessTo(permission))
                {
                    result.Add(new Permission(permission.Identifier, permission.Description));
                }
            }

            return result;
        }

        public IPermissionCollection AssignDescriptionsUsing(IPermissionCollection permissions)
        {
            foreach (var permission in this)
            {
                var described =
                    permissions.Find(
                        item =>
                        item.Identifier.Equals(permission.Identifier, StringComparison.InvariantCultureIgnoreCase));

                if (described != null)
                {
                    permission.Description = described.Description;
                }
            }

            return this;
        }
    }
}