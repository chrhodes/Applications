using VNC.Core.DomainServices;

namespace PAEF3.Domain.Lookups
{
    public class LookupCat : ILookupItem<int>
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
    }
}
