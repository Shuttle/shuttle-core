using System;

namespace Shuttle.Core.Infrastructure
{
    public class Permission : IPermission
    {
        public Permission()
        {
        }

        public Permission(string identifier)
            : this(identifier, identifier)
        {
        }

        public Permission(string identifier, string description)
        {
            Identifier = identifier;
            Description = description;
        }

        public string Identifier { get; set; }
        public string Description { get; set; }

        public bool IsSatisfiedBy(IPermissionCollection permissions)
        {
            Guard.AgainstNull(permissions, "permissions");

            return permissions.HasAccessTo(Identifier);
        }

        public override string ToString()
        {
            return Identifier;
        }

        public static implicit operator string(Permission permission)
        {
            return permission.Identifier;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            var other = obj as IPermission;

            return (other == null
                        ? Convert.ToString(obj)
                        : other.Identifier).Equals(Identifier,
                                                   StringComparison.
                                                       InvariantCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return Identifier.ToLower().GetHashCode();
        }
    }
}
