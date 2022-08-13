using VNC.Core.DomainServices;

namespace PAEF2.Domain.Lookups
{
    public class LookupTYPE : ILookupItem<int>
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
    }
}
