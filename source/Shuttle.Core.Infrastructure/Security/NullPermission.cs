namespace Shuttle.Core.Infrastructure
{
    public class NullPermission : IPermission
    {
        public static readonly IPermission Instance = new NullPermission();

        private NullPermission()
        {
            Identifier = string.Empty;
            Description = string.Empty;
        }

        public string Identifier { get; set; }
        public string Description { get; set; }
        
        public bool IsSatisfiedBy(IPermissionCollection item)
        {
            return true;
        }
    }
}
