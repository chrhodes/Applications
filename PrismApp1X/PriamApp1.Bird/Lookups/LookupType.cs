using VNC.Core.Domain;

namespace PriamApp1.Bird.Lookups
{
    public class LookupTYPE : ILookupItem<int>
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
    }
}
